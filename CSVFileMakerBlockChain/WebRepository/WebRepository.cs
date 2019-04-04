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
        private IParserFactory _parserFactory;

        public HtmlWeb web { get; set; }
        public HtmlNode nodes_block_heights { get; set; }
        public HtmlNode nodes_block_transactions { get; set; }
        public HtmlNode node_blocks { get; set; }

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
                ParseBlocks(block_height);
            }

            return _parserFactory.GetBlockHeights();
        }

        public async Task<IEnumerable<IBlockHeight>> ParseBlockHeightAsync(int height)
        {
            return await Task.Run(() => ParseBlockHeight(height));
        }

        public IEnumerable<IBlock> ParseBlocks(IBlockHeight blockheight)
        {
            string url = build_Url(blockheight.Hash);
            var div_block = web.Load(url).DocumentNode.Descendants("div").Where
                (a => a.Attributes.Contains("class") && a.Attributes["class"].Value.Contains("col-md-6 col-sm-6")).ToList();

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

        
        public IEnumerable<ITransaction> ParseTransactions(IBlock block)
        {
            return _parserFactory.GetTransactions(block);
        }


        #region private methods
        private void populate_Blockheight_Obj_prop(IBlockHeight block_height, HtmlNodeCollection cells, HtmlNode cell)
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

        private void populate_Block_Obj_Prop(IBlock block, HtmlNodeCollection cells, HtmlNode cell)
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

        private string getCellValue(HtmlNodeCollection cells)
        {
            return cells[1].InnerText.TrimEnd();
        }

        private string build_Url(int height)
        {
            var url_builder = new StringBuilder(StaticData.url_block_height);
            var url = url_builder.Append(height).ToString();
            return url;
        }

        private string build_Url(string hash)
        {
            var url_builder = new StringBuilder(StaticData.url_block);
            var url = url_builder.Append(hash).ToString();
            return url;
        } 
        #endregion
    }
}
