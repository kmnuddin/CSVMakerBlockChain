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

        HtmlNode nodes_block_heights { get; set; }
        HtmlNode nodes_block_transactions { get; set; }
        HtmlNode node_blocks { get; set; }

    }
}
