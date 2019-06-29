using CSVFileMakerBlockChain.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Repository
{
    public class WebRepository : IWebRepository
    {
        IParserFactory _parserFactory;

        public HtmlWeb web { get; set; }
        public HtmlNode node { get; set; }

        public WebRepository(IParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }

        public IEnumerable<IBlockHeight> ParseBlockHeight(int height)
        {
            string url = build_Url(height);
            var tables = web.Load(url).DocumentNode.SelectNodes("//table");

            foreach (var table in tables)
            {
                var block_height = IoC.GlobalContainer.Resolve<IBlockHeight>();

                foreach (var rows in table.SelectNodes("tr"))
                {
                    var cells = rows.SelectNodes("th|td");
                    foreach (var cell in cells)
                    {
                        populate_Blockheight_Obj_prop(block_height, cells, cell);
                    }
                }
                _parserFactory.AddBlockHeight(block_height);
            }

            return _parserFactory.GetBlockHeights();
        }

        public IEnumerable<IBlock> ParseBlocks(IBlockHeight blockheight)
        {
            string url = build_Url(blockheight.Hash + "?show_adv=true");

            node = web.Load(url).DocumentNode;
            var div_block = node.Descendants("div").Where(fromClass("col-md-6 col-sm-6")).ToList();

            var table = div_block[0].SelectNodes("//table");

            var block = IoC.GlobalContainer.Resolve<IBlock>();
            block.Height = blockheight;

            foreach (var rows in table[0].SelectNodes("tr"))
            {
                var cells = rows.SelectNodes("th|td");

                foreach (var cell in cells)
                {
                    populate_Block_Obj_Prop(block, cells, cell);
                }
            }
            _parserFactory.AddBlocks(block);

            return _parserFactory.GetBlocks();
        }

        public IEnumerable<string> ParseTransactionIDs()
        {
            var div_trans = node.Descendants("div").Where(fromClass("txdiv")).ToList();
            var transaction_ids = new List<string>();

            foreach (var div in div_trans)
            {
                var trans_table = div.Descendants("table").ToList();

                foreach (var rows in trans_table[0].SelectNodes("tr"))
                {

                    var cells = rows.SelectNodes("th|td");
                    foreach (var cell in cells)
                    {
                        var transaction_id = cell.Descendants("a").
                            Where(fromClass("hash-link")).
                            SingleOrDefault();

                        if (transaction_id != null)
                        {
                            transaction_ids.Add(transaction_id.InnerText);
                        }
                        else
                            break;
                    }
                }

            }

            return transaction_ids;
        }

        public IEnumerable<ITransaction> ParseTransactions(IBlock block, string transaction_id)
        {
            string url = build_Url_tx(transaction_id);
            var nodetx = web.Load(url).DocumentNode;

            var txdiv = nodetx.Descendants("div").Single(fromClass("txdiv"));
            var tx_sum_io = nodetx.Descendants("div").Where(fromClass("col-md-6 col-sm-6"));

            var block_transaction = IoC.GlobalContainer.Resolve<ITransaction>();

            block_transaction.TransactionID = transaction_id;

            var txdiv_senders = txdiv.Descendants("td").Single(fromClass("txtd hidden-phone mobile-f12 stack-mobile")).ChildNodes;

            foreach (var txdiv_sender in txdiv_senders)
            {

            }

            return null;
        }

        public IEnumerable<ITransaction> ParseTransactions_OPT(IBlock block)
        {
            var div_trans = node.Descendants("div").Where(fromClass("txdiv")).ToList();
            //var trs = div_trans.Single(fromClass("hash-link")).ChildNodes;

            foreach (var div in div_trans)
            {
                var tx_obj = IoC.GlobalContainer.Resolve<ITransaction>();
                tx_obj.Block = block;

                var trs = div.Descendants("tr").ToList();

                var trs_id = trs[0].Descendants("a").Where(fromClass("hash-link")).ToList();
                tx_obj.TransactionID = trs_id[0].InnerText.TrimEnd();

                var trs_size_fee = trs[0].Descendants("span").Where(fromClass("hidden-phone")).ToList();
                var size_fee_raw = trs_size_fee[0].InnerText.Split(new char[] { ':', '-', '(', ')' });

                tx_obj.Fee = size_fee_raw.SingleOrDefault(a => a.Contains("BTC"));
                tx_obj.Size = size_fee_raw.SingleOrDefault(a => a.Contains("bytes"));

                var tds_sender_reciever = trs[1].Descendants("td").ToList();

                var tds_sender = tds_sender_reciever.SingleOrDefault(fromClass("txtd hidden-phone mobile-f12 stack-mobile"));

                var tds_sender_raw_hashes = tds_sender.Descendants("a").Where(a => !a.InnerText.Contains("Output") && !string.IsNullOrWhiteSpace(a.InnerText)).ToList();
                var tds_sender_raw_amounts = tds_sender.Descendants("span").Where(a => a.InnerText.Contains("BTC")).ToList();

                var tds_reciever = tds_sender_reciever.SingleOrDefault(fromClass("txtd mobile-f12 stack-mobile"));

                var tds_reciever_raw_hashes = tds_reciever.Descendants("a").
                    Where(a => !a.InnerText.Contains("Spent") && !a.InnerText.Contains("Unspent") && !string.IsNullOrWhiteSpace(a.InnerText)).ToList();
                var tds_reciever_raw_amounts = tds_reciever.Descendants("span").Where(fromClass("pull-right hidden-phone")).ToList();



                if (tds_sender_raw_hashes.Count == 0)
                {
                    for (int i = 0; i < tds_reciever_raw_hashes.Count; i++)
                    {
                        var tx_sender = IoC.GlobalContainer.Resolve<ISenderReciever>();
                        var tx_reciever = IoC.GlobalContainer.Resolve<ISenderReciever>();

                        tx_sender.Amount = tds_reciever_raw_amounts[0].InnerText;
                        tx_sender.Hash = "";

                        tx_reciever.Amount = tds_reciever_raw_amounts[0].InnerText;
                        tx_reciever.Hash = tds_reciever_raw_hashes[0].InnerText;

                        _parserFactory.AddSender(tx_obj, tx_sender);
                        _parserFactory.AddReciever(tx_obj, tx_reciever);


                    }
                    _parserFactory.AddTransaction(block, tx_obj);
                    continue;
                }

                for (int i = 0; i < tds_sender_raw_hashes.Count; i++)
                {
                    var tx_sender = IoC.GlobalContainer.Resolve<ISenderReciever>();
                    tx_sender.Amount = tds_sender_raw_amounts[0].InnerText;
                    tx_sender.Hash = tds_sender_raw_hashes[0].InnerText;

                    _parserFactory.AddSender(tx_obj, tx_sender);
                }

                for (int i = 0; i < tds_reciever_raw_hashes.Count; i++)
                {
                    var tx_reciever = IoC.GlobalContainer.Resolve<ISenderReciever>();
                    tx_reciever.Amount = tds_reciever_raw_amounts[0].InnerText;
                    tx_reciever.Hash = tds_reciever_raw_hashes[0].InnerText;

                    _parserFactory.AddReciever(tx_obj, tx_reciever);
                }
                _parserFactory.AddTransaction(block, tx_obj);


            }
            return _parserFactory.GetTransactions(block).ToList();

        }

        public async Task<IEnumerable<IBlockHeight>> ParseBlockHeightAsync(int height)
        {
            return await Task.Run(() => ParseBlockHeight(height));
        }

        public async Task<IEnumerable<IBlock>> ParseBlocksAsync(IBlockHeight blockHeight)
        {
            return await Task.Run(() => ParseBlocks(blockHeight));
        }

        public async Task<IEnumerable<ITransaction>> ParseTransactionsAsync(IBlock block, string transaction_id)
        {
            return await Task.Run(() => ParseTransactions(block, transaction_id));
        }

        public async Task<IEnumerable<string>> ParseTransactionIDsAsync()
        {
            return await Task.Run(() => ParseTransactionIDs());
        }

        public async Task<IEnumerable<ITransaction>> ParseTransactions_OPT_Async(IBlock block)
        {
            return await Task.Run(() => ParseTransactions_OPT(block));
        }


        #region private methods
        Func<HtmlNode, bool> fromClass(string class_val)
        {
            return a => a.Attributes.Contains("class") && a.Attributes["class"].Value.Contains(class_val);
        }

        void populate_Blockheight_Obj_prop(IBlockHeight block_height, HtmlNodeCollection cells, HtmlNode cell)
        {
            switch (cell.InnerText)
            {
                case "Height":
                    block_height.Height = getCellValue(cells);
                    break;
                case "Hash":
                    block_height.Hash = getCellValue(cells);
                    break;
            }
        }

        void populate_Block_Obj_Prop(IBlock block, HtmlNodeCollection cells, HtmlNode cell)
        {
            switch (cell.InnerText)
            {
                case "Number Of Transactions":
                    block.N_trans = getCellValue(cells);
                    break;
                case "Output Total":
                    block.Output_Total = getCellValue(cells);
                    break;
                case "Estimated Transaction Volume":
                    block.Estimated_Transaction_Volume = getCellValue(cells);
                    break;
                case "Transaction Fees":
                    block.Transaction_Fees = getCellValue(cells);
                    break;
                case "Timestamp":
                    block.Timestamp = getCellValue(cells);
                    break;
                case "Received Time":
                    block.Received_Time = getCellValue(cells);
                    break;
                case "Relayed By":
                    block.Relayed_By = getCellValue(cells);
                    break;
                case "Difficulty":
                    block.Difficulty = getCellValue(cells);
                    break;
                case "Bits":
                    block.Bits = getCellValue(cells);
                    break;
                case "Size":
                    block.Size = getCellValue(cells);
                    break;
                case "Weight":
                    block.Weight = getCellValue(cells);
                    break;
                case "Version":
                    block.Version = getCellValue(cells);
                    break;
                case "Nonce":
                    block.Nonce = getCellValue(cells);
                    break;
                case "Block Reward":
                    block.Block_Reward = getCellValue(cells);
                    break;

            }
        }

        string getCellValue(HtmlNodeCollection cells)
        {
            return cells[1].InnerText.TrimEnd();
        }

        string build_Url(int height)
        {
            var url_builder = new StringBuilder(StaticData.url_block_height);
            var url = url_builder.Append(height).ToString();
            return url;
        }

        string build_Url(string hash)
        {
            var url_builder = new StringBuilder(StaticData.url_block);
            var url = url_builder.Append(hash).ToString();
            return url;
        }

        string build_Url_tx(string transaction_id)
        {
            var url_builder = new StringBuilder(StaticData.url_transaction);
            var url = url_builder.Append(transaction_id).ToString();
            return url;
        }

        private static bool IsNodeVisible(HtmlNode node)
        {
            var attribute = node.Attributes["style"];

            bool thisVisible = false;

            if (attribute == null || CheckStyleVisibility(attribute.Value))
                thisVisible = true;

            if (thisVisible && node.ParentNode != null)
                return IsNodeVisible(node.ParentNode);

            return thisVisible;
        }

        static bool CheckStyleVisibility(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return true;

            var keys = ParseHtmlStyleString(style);

            if (keys.Keys.Contains("display"))
            {
                string display = keys["display"];
                if (display != null && display == "none")
                    return false;
            }

            if (keys.Keys.Contains("visibility"))
            {
                string visibility = keys["visibility"];
                if (visibility != null && visibility == "hidden")
                    return false;
            }

            return true;
        }

        static Dictionary<string, string> ParseHtmlStyleString(string style)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            style = style.Replace(" ", "").ToLowerInvariant();

            string[] settings = style.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in settings)
            {
                if (!s.Contains(':'))
                    continue;
                string[] data = s.Split(':');
                result.Add(data[0], data[1]);
            }

            return result;
        }


        #endregion
    }
}
