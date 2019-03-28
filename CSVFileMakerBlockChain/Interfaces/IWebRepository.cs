using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Interfaces
{
    public interface IWebRepository
    {
        IEnumerable<IBlockHeight> ParseBlockHeights(int from, int to);
        IEnumerable<IBlock> ParseBlocks(IEnumerable<IBlockHeight> blockheights);
        IEnumerable<ITransaction> ParseTransactions(IBlock block);

        IEnumerable<HtmlNode> nodes_block_heights { get; set; }
        IEnumerable<HtmlNode> nodes_block_transactions { get; set; }
        IEnumerable<HtmlNode> node_blocks { get; set; }

    }
}
