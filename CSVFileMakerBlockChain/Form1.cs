using CSVFileMakerBlockChain.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CSVFileMakerBlockChain
{
    public partial class Form1 : Form
    {
        private IViewModel _viewModel;

        public Form1(IViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
        }

        private void Gnrt_Blocks_Transactions_Click(object sender, EventArgs e)
        {
            try
            {
                var ranges = Blk_Range_Txtbox.Text.Split(new char[] { '-' });

                if (ranges.Length > 1)
                    _viewModel.Populate_Block_ListAsync(Block_List, int.Parse(ranges[0]), int.Parse(ranges[1]));
                else
                    _viewModel.Populate_Block_ListAsync(Block_List, int.Parse(ranges[0]), int.Parse(ranges[0]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void Blk_Range_Txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string txt = (sender as TextBox).Text;

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar == '-')
            {
                if (txt.Length != 0 && !txt.Contains('-'))
                {
                    e.Handled = false;
                    return;
                }

            }
            e.Handled = true;

        }

        private void Blk_Range_Txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Gnrt_Blocks_Transactions_Click(sender, e);
            }
        }

        private void Block_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listbox = sender as ListBox;
            var block_table = _viewModel.dataSet_block.Tables[listbox.SelectedIndex];

            DataGridView_block.DataSource = block_table;
        }
    }
}
