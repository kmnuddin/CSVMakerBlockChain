using CSVFileMakerBlockChain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVFileMakerBlockChain.View_Model
{
    public class ViewModel : IViewModel
    {
        public IList<IBlockHeight> nodes_block_heights { get; set; }
        public IList<ITransaction> nodes_block_transactions { get; set; }
        public IList<IBlock> node_blocks { get; set; }

        IWebRepository _webRepository;
        IList<string> transaction_ids;
        DataSet _dataset;

        public ViewModel(IWebRepository webRepository, DataSet dataSet)
        {
            _webRepository = webRepository;
            _dataset = dataSet;

        }

        public async Task Populate_Block_ListAsync(ListBox listbox, int from, int to)
        {
            try
            {
                for (int height = from; height <= to; height++)
                {
                    nodes_block_heights = (List<IBlockHeight>)await _webRepository.ParseBlockHeightAsync(height);

                    node_blocks = (List<IBlock>)await _webRepository.ParseBlocksAsync(nodes_block_heights.Last());

                    //transaction_ids = (List<string>) await _webRepository.ParseTransactionIDsAsync();
                    nodes_block_transactions = (List<ITransaction>)await _webRepository.ParseTransactions_OPT_Async(node_blocks.Last());
                    //foreach (var id in transaction_ids)
                    //{
                    //   // nodes_block_transactions = (List<ITransaction>)await _webRepository.ParseTransactionsAsync(node_blocks.Last(), id); 

                    //}

                    var dt = await Task.Run(() => Construct_Datatable_for_block(node_blocks.Last()));

                    BindingList<IBlockHeight> binding_list = new BindingList<IBlockHeight>(nodes_block_heights);

                    listbox.DataSource = binding_list;
                    listbox.DisplayMember = "Height";
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
            }
        }

        public DataTable Construct_Datatable_for_block(IBlock block)
        {
            var dt = IoC.GlobalContainer.Resolve<DataTable>();

            var props = block.GetType().GetProperties();

            foreach (var prop in props)
            {
                var dt_col = IoC.GlobalContainer.Resolve<DataColumn>();
                dt_col.DataType = prop.PropertyType;
                dt_col.ColumnName = prop.Name;

                dt.Columns.Add(dt_col);
            }

            return dt;
        }

        public DataTable Construct_Datatable_for_tx(ICollection<ITransaction> transactions)
        {
            throw new NotImplementedException();
        }

        public DataSet Get_All_dt_blocks_tx()
        {
            throw new NotImplementedException();
        }
    }
}
