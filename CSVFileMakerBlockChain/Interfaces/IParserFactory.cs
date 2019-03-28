using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Interfaces
{
    public interface IParserFactory
    {
        IBlockHeight GetBlockHeight(string height);
        IBlock GetBlock(IBlockHeight height);
        ITransaction GetTransaction(IBlock block,string transaction_id);
        IEnumerable<IBlockHeight> GetBlockHeights();
        IEnumerable<IBlock> GetBlocks();
        IEnumerable<ITransaction> GetTransactions(IBlock block);

        void AddBlockHeight(IBlockHeight blockheight);
        void AddBlocks(IBlock block);
        void AddTransaction(IBlock block, ITransaction transaction);
        void AddTransactions(IBlock block, IEnumerable<ITransaction> transactions);

    }
}
