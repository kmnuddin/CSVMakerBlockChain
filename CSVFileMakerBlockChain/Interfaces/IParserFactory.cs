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
        ICollection<IBlockHeight> GetBlockHeights();
        ICollection<IBlock> GetBlocks();
        ICollection<ITransaction> GetTransactions(IBlock block);
        ICollection<ISenderReciever> GetSenders(ITransaction transaction);
        ICollection<ISenderReciever> GetRecievers(ITransaction transaction);

        void AddBlockHeight(IBlockHeight blockheight);
        void AddBlocks(IBlock block);
        void AddTransaction(IBlock block, ITransaction transaction);
        void AddTransactions(IBlock block, ICollection<ITransaction> transactions);
        void AddSender(ITransaction transaction, ISenderReciever sender);
        void AddSenders(ITransaction transaction, ICollection<ISenderReciever> senders);
        void AddReciever(ITransaction transaction, ISenderReciever reciever);
        void AddRecievers(ITransaction transaction, ICollection<ISenderReciever> recievers);


    }
}
