using CSVFileMakerBlockChain.Parser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Parser.Model
{
    public class BlockHeight : IBlockHeight
    {
        public string Hash { get; set; }
        string IBlockHeight.BlockHeight { get; set; }
    }
}
