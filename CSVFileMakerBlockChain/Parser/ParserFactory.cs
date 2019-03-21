using CSVFileMakerBlockChain.Parser.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Parser
{
    public class ParserFactory : IParserFactory
    {
        private IEnumerable<IBlockHeight> block_heights;

        public ParserFactory()
        {
            
        }

        public IEnumerable<IBlockHeight> GetAllBlockHeightsFromRange(int from, int to)
        {
            var web = new HtmlWeb();
            for (int height = from; height <= to; height++)
            {
                StringBuilder url = initialize_Url(StaticData.url_block_height);
                
                var html_doc = web.Load(construct_url_using_height(url, height)).DocumentNode;

                var html_table = html_doc.Descendants("table").Where(a => a.GetAttributeValue("class", "").Contains("table table-striped"));



            }
            return block_heights;
        }

        private StringBuilder initialize_Url(string url) => new StringBuilder(url);
        private string construct_url_using_height(StringBuilder url, int height) => url.Append(height.ToString()).ToString();

       
    }
}
