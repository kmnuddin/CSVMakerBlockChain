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
        public IEnumerable<HtmlNode> nodes_block_heights { get; set; }
        public IEnumerable<HtmlNode> nodes_block_transactions { get; set; }
        public IEnumerable<HtmlNode> node_blocks { get; set; }


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
                nodes_block_heights = web.Load(url).DocumentNode.Descendants("div").Where(a => a.GetAttributeValue("class", "").Contains("row"));
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
