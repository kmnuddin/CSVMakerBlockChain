﻿using HtmlAgilityPack;
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
        IEnumerable<ITransaction> ParseTransactions(IBlock block, IEnumerable<string> transaction_ids);
        IEnumerable<string> ParseTransactionIDs();

        Task<IEnumerable<IBlockHeight>> ParseBlockHeightAsync(int height);
        Task<IEnumerable<IBlock>> ParseBlocksAsync(IBlockHeight blockHeight);
        Task<IEnumerable<string>> ParseTransactionIDsAsync();

        HtmlWeb web { get; set; }
        HtmlNode node { get; set; }
    }
}
