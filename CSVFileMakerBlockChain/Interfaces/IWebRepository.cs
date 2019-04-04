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
        IEnumerable<ITransaction> ParseTransactions(IBlock block, HtmlNode transaction_node);
        Task<IEnumerable<IBlockHeight>> ParseBlockHeightAsync(int height);


        IList<IBlockHeight> nodes_block_heights { get; set; }
        IList<ITransaction> nodes_block_transactions { get; set; }
        IList<IBlock> node_blocks { get; set; }

    }
}
