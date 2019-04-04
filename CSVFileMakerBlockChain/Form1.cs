
using CSVFileMakerBlockChain.Interfaces;
using CSVFileMakerBlockChain.Properties;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                _viewModel.Populate_Block_ListAsync(Block_List, 565578, 565598);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
