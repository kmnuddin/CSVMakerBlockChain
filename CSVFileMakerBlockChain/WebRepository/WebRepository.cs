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

        public IEnumerable<IBlockHeight> ParseBlockHeights(int from, int to)
        {
            var url_builder = new StringBuilder(StaticData.url_block_height);
            
            for(int height = from; height <= to; height++)
            {
                var url = url_builder.Append(height).ToString();
                var tables = web.Load(url).DocumentNode.SelectNodes("//table");

                foreach(var table in tables)
                {
                    var block_height = IoC.GlobalContainer.Resolve<IBlockHeight>();

                    foreach (var rows in table.SelectNodes("tr"))
                    {
                        var cells = rows.SelectNodes("th|td");
                        foreach (var cell in cells)
                        {
                            if(cell.InnerText == "Height")
                            {
                                block_height.Height = cells[1].InnerText;
                                break;
                            }

                            if(cell.InnerText == "Hash")
                            {
                                block_height.Hash = cells[1].InnerText.TrimEnd();
                                break;
                            }
                        }
                    }
                    _parserFactory.AddBlockHeight(block_height);

                } 
            }

            return _parserFactory.GetBlockHeights();
        }

        public IEnumerable<IBlock> ParseBlocks(IEnumerable<IBlockHeight> blockheights)
        {
            return _parserFactory.GetBlocks();
        }

        public IEnumerable<ITransaction> ParseTransactions(IBlock block)
        {
            return _parserFactory.GetTransactions(block);
        }

    }
}
