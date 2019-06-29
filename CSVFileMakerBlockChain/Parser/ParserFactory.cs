using CSVFileMakerBlockChain.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Model
{
    public class ParserFactory : IParserFactory
    {
        private readonly IList<IBlockHeight> _blockheights;
        private readonly IList<IBlock> _blocks;

        public ParserFactory(ICollection<IBlockHeight> blockheights, ICollection<IBlock> blocks)
        {
            _blockheights = blockheights.ToList();
            _blocks = blocks.ToList();
        }

        public IBlockHeight GetBlockHeight(string height)
        {
            return _blockheights.SingleOrDefault(a => a.Height == height);
        }

        public IBlock GetBlock(IBlockHeight blockheight)
        {
            return _blocks.SingleOrDefault(a => a.Height.Height == blockheight.Height);
        }

        public ITransaction GetTransaction(IBlock block, string transaction_id)
        {

            return block.Transactions.SingleOrDefault(a => a.TransactionID == transaction_id);
        }

        public ICollection<IBlockHeight> GetBlockHeights()
        {
            for (int i = 0; i < _blockheights.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(_blockheights[i].Height) || String.IsNullOrWhiteSpace(_blockheights[i].Hash))
                    _blockheights.RemoveAt(i);
            }
            return _blockheights;
        }

        public ICollection<IBlock> GetBlocks()
        {
            for (int i = 0; i < _blocks.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(_blocks[i].Height.Height))
                    _blocks.RemoveAt(i);
            }
            return _blocks;
        }

        public ICollection<ITransaction> GetTransactions(IBlock block)
        {
            for (int i = 0; i < block.Transactions.Count(); i++)
            {
                if (String.IsNullOrWhiteSpace(block.Transactions.ElementAt(i).TransactionID))
                    block.Transactions.ToList().RemoveAt(i);
            }
            return block.Transactions;
        }

        public void AddBlockHeight(IBlockHeight blockheight)
        {
            _blockheights.Add(blockheight);
        }

        public void AddBlocks(IBlock block)
        {
            _blocks.Add(block);
        }

        public void AddTransaction(IBlock block, ITransaction transaction)
        {
            if (block.Transactions.IsReadOnly)
            {
                block.Transactions = new List<ITransaction>();
            }
            block.Transactions.Add(transaction);
        }

        public void AddTransactions(IBlock block, ICollection<ITransaction> transactions)
        {
            if (block.Transactions.IsReadOnly)
            {
                block.Transactions = new List<ITransaction>();
            }
            block.Transactions.ToList().AddRange(transactions);
            
        }

        public ICollection<ISenderReciever> GetSenders(ITransaction transaction)
        {
            return transaction.Senders;
        }

        public ICollection<ISenderReciever> GetRecievers(ITransaction transaction)
        {
            return transaction.Receivers;
        }

        public void AddSender(ITransaction transaction, ISenderReciever sender)
        {
            if (transaction.Senders.IsReadOnly)
            {
                transaction.Senders = new List<ISenderReciever>();
            }
            transaction.Senders.Add(sender);
        }

        public void AddSenders(ITransaction transaction, ICollection<ISenderReciever> senders)
        {
            if (transaction.Senders.IsReadOnly)
            {
                transaction.Senders = new List<ISenderReciever>();
            }
            transaction.Senders.ToList().AddRange(senders);
        }

        public void AddReciever(ITransaction transaction, ISenderReciever reciever)
        {
            if (transaction.Receivers.IsReadOnly)
            {
                transaction.Receivers = new List<ISenderReciever>();
            }
            transaction.Receivers.Add(reciever);
        }

        public void AddRecievers(ITransaction transaction, ICollection<ISenderReciever> recievers)
        {
            if (transaction.Receivers.IsReadOnly)
            {
                transaction.Receivers = new List<ISenderReciever>();
            }
            transaction.Receivers.ToList().AddRange(recievers);
        }
    }
}
