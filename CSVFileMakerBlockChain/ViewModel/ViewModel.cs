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
        public DataSet dataSet { get; set; }

        IWebRepository _webRepository;
        IList<string> transaction_ids;
        

        public ViewModel(IWebRepository webRepository)
        {
            _webRepository = webRepository;
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
                    dataSet.Tables.Add(dt);


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
            var dt = new DataTable();
            dt.TableName = block.Height.Height;

            var props = block.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (!prop.Name.Equals("Transactions", StringComparison.CurrentCultureIgnoreCase))
                {
                    var dt_col = IoC.GlobalContainer.Resolve<DataColumn>();
                    if (!prop.Name.Equals("Height", StringComparison.CurrentCultureIgnoreCase))
                    {
                        dt_col.DataType = prop.PropertyType; 
                    }
                    else
                    {
                        dt_col.DataType = typeof(string);
                    }
                    dt_col.ColumnName = prop.Name;

                    dt.Columns.Add(dt_col);
                }
                
            }
            var row = dt.NewRow();
            foreach (var prop in props)
            {
                if (prop.Name.Equals("Transactions", StringComparison.CurrentCultureIgnoreCase))
                    continue;
                if(!prop.Name.Equals("Height", StringComparison.CurrentCultureIgnoreCase))
                {
                    row[prop.Name] = prop.GetValue(block);
                }
                else
                {
                    row[prop.Name] = block.Height.Height;
                }
            }

            dt.Rows.Add(row);

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
