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
        IEnumerable<IBlockHeight> ParseBlockHeight(int height);
        IEnumerable<IBlock> ParseBlocks(IBlockHeight blockheight);
        IEnumerable<ITransaction> ParseTransactions(IBlock block);
        Task<IEnumerable<IBlockHeight>> ParseBlockHeightAsync(int height);


        HtmlNode nodes_block_heights { get; set; }
        HtmlNode nodes_block_transactions { get; set; }
        HtmlNode node_blocks { get; set; }

    }
}
