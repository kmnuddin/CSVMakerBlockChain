using CSVFileMakerBlockChain.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Model
{
    public class ParserFactory : IParserFactory
    {
        private readonly IList<IBlockHeight> _blockheights;
        private readonly IList<IBlock> _blocks;
        
        public ParserFactory(IEnumerable<IBlockHeight> blockheights, IEnumerable<IBlock> blocks)
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

        public IEnumerable<IBlockHeight> GetBlockHeights()
        {
            return _blockheights;
        }

        public IEnumerable<IBlock> GetBlocks()
        {
            return _blocks;
        }

        public IEnumerable<ITransaction> GetTransactions(IBlock block)
        {
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
            block.Transactions.ToList().Add(transaction);
        }

        public void AddTransactions(IBlock block, IEnumerable<ITransaction> transactions)
        {
            block.Transactions = transactions;
        }
    }
}
