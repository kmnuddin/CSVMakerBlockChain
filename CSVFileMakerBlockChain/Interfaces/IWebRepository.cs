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
        IEnumerable<ITransaction> ParseTransactions(IBlock block);


        Task<IEnumerable<IBlockHeight>> ParseBlockHeightAsync(int height);
        Task<IEnumerable<IBlock>> ParseBlocksAsync(IBlockHeight blockHeight);
        Task<IEnumerable<ITransaction>> ParseTransactionsAsync(IBlock block);

        HtmlWeb web { get; set; }
        HtmlNode node { get; set; }
    }
}
