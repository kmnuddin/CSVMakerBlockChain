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
                _viewModel.Populate_Block_ListAsync(Block_List, int.Parse(ranges[0]), int.Parse(ranges[1]));
            }
            catch (Exception)
            {

                throw;
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
    }
}
