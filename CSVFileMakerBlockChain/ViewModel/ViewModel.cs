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
        public DataSet dataSet_block { get; set; }
        public DataSet dataSet_tx { get; set; }

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
                BindingList<IBlockHeight> binding_list = Init_local_repo();
                for (int height = from; height <= to; height++)
                {
                    nodes_block_heights = (List<IBlockHeight>)await _webRepository.ParseBlockHeightAsync(height);

                    var latest_block_h_aux = Regex.Match(nodes_block_heights.Last().Height, @"\d+").Value;

                    if (nodes_block_heights.Count > 1)
                    {
                        var block_heights_w_aux = nodes_block_heights.Where(a => a.Height.Contains(latest_block_h_aux));

                        if (block_heights_w_aux.Count() >= 2)
                        {
                            await Populate_block_w_aux(listbox, binding_list, block_heights_w_aux);
                            continue;
                        }
                    }


                    node_blocks = (List<IBlock>)await _webRepository.ParseBlocksAsync(nodes_block_heights.Last());

                    //transaction_ids = (List<string>) await _webRepository.ParseTransactionIDsAsync();
                    nodes_block_transactions = (List<ITransaction>)await _webRepository.ParseTransactions_OPT_Async(node_blocks.Last());
                    //foreach (var id in transaction_ids)
                    //{
                    //   // nodes_block_transactions = (List<ITransaction>)await _webRepository.ParseTransactionsAsync(node_blocks.Last(), id); 

                    //}

                    var dt_block = await Task.Run(() => Construct_Datatable_for_block(node_blocks.Last()));
                    dataSet_block.Tables.Add(dt_block);

                    var dt_tx = await Task.Run(() => Construct_Datatable_for_tx(node_blocks.Last(), nodes_block_transactions));
                    dataSet_tx.Tables.Add(dt_tx);

                    binding_list.Add(nodes_block_heights.Last());
                    listbox.DataSource = binding_list;
                    listbox.DisplayMember = "Height";
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private async Task Populate_block_w_aux(ListBox listbox, BindingList<IBlockHeight> binding_list, IEnumerable<IBlockHeight> block_heights_w_aux)
        {
            foreach (var block_height_w_aux in block_heights_w_aux)
            {
                node_blocks = (List<IBlock>)await _webRepository.ParseBlocksAsync(block_height_w_aux);
                nodes_block_transactions = (List<ITransaction>)await _webRepository.ParseTransactions_OPT_Async(node_blocks.Last());
                var dt_block_aux = await Task.Run(() => Construct_Datatable_for_block(node_blocks.Last()));
                dataSet_block.Tables.Add(dt_block_aux);

                var dt_tx_aux = await Task.Run(() => Construct_Datatable_for_tx(node_blocks.Last(), nodes_block_transactions));
                dataSet_tx.Tables.Add(dt_tx_aux);


                binding_list.Add(block_height_w_aux);

                listbox.DataSource = binding_list;
                listbox.DisplayMember = "Height";
            }
        }

        private BindingList<IBlockHeight> Init_local_repo()
        {
            BindingList<IBlockHeight> binding_list = new BindingList<IBlockHeight>();
            //if (node_blocks.Count > 0)
            //{
            //    node_blocks.Clear();
            //    nodes_block_heights.Clear();
            //    nodes_block_transactions.Clear(); 
            //}
            return binding_list;
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
                if (!prop.Name.Equals("Height", StringComparison.CurrentCultureIgnoreCase))
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

        public DataTable Construct_Datatable_for_tx(IBlock block, ICollection<ITransaction> transactions)
        {
            var dt = new DataTable();
            dt.TableName = block.Height.Height;
            var props = typeof(ITransaction).GetProperties();
            foreach (var prop in props)
            {
                var dt_col = IoC.GlobalContainer.Resolve<DataColumn>();
                if (prop.Name.Equals("Senders", StringComparison.CurrentCultureIgnoreCase) || prop.Name.Equals("Receivers", StringComparison.CurrentCultureIgnoreCase)
                    || prop.Name.Equals("Block", StringComparison.CurrentCultureIgnoreCase))
                {
                    dt_col.DataType = typeof(string);
                }
                else
                {
                    dt_col.DataType = prop.PropertyType;

                }
                dt_col.ColumnName = prop.Name;
                dt.Columns.Add(dt_col);
                if (prop.Name.Equals("Senders", StringComparison.CurrentCultureIgnoreCase))
                {
                    var dt_col_amount_sn = IoC.GlobalContainer.Resolve<DataColumn>();
                    dt_col_amount_sn.DataType = typeof(string);
                    dt_col_amount_sn.ColumnName = "amount_sn";
                    dt.Columns.Add(dt_col_amount_sn);
                }
                if (prop.Name.Equals("Receivers", StringComparison.CurrentCultureIgnoreCase))
                {
                    var dt_col_amount_tx = IoC.GlobalContainer.Resolve<DataColumn>();
                    dt_col_amount_tx.DataType = typeof(string);
                    dt_col_amount_tx.ColumnName = "amount_rc";
                    dt.Columns.Add(dt_col_amount_tx);
                }
            }
            foreach (var tx in transactions)
            {
                var count_sn = tx.Senders.Count;
                var count_rc = tx.Receivers.Count;
                foreach (var sn in tx.Senders)
                {
                    foreach (var rc in tx.Receivers)
                    {
                        var row = dt.NewRow();
                        foreach (var prop in props)
                        {
                            if (prop.Name.Equals("Senders", StringComparison.CurrentCultureIgnoreCase))
                            {
                                row[prop.Name] = sn.Hash;
                                row["amount_sn"] = sn.Amount;
                            }
                            else if (prop.Name.Equals("Receivers", StringComparison.CurrentCultureIgnoreCase))
                            {
                                row[prop.Name] = rc.Hash;
                                row["amount_rc"] = rc.Amount;
                            }
                            else if (prop.Name.Equals("Block", StringComparison.CurrentCultureIgnoreCase))
                            {
                                row[prop.Name] = tx.Block.Height.Height;
                            }
                            else
                            {
                                row[prop.Name] = prop.GetValue(tx);
                            }
                        }

                        dt.Rows.Add(row);
                    }
                }
            }

            return dt;
        }

        public DataSet Get_All_dt_blocks_tx()
        {
            throw new NotImplementedException();
        }
    }
}
