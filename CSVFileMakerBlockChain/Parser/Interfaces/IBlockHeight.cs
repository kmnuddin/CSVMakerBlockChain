using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Parser.Interfaces
{
    public interface IBlockHeight
    {
        string BlockHeight { get; set; }
        string Hash { get; set; }
    }
}
