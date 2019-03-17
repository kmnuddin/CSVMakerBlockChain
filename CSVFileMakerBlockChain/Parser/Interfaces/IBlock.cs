using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Parser.Interfaces
{
    public interface IBlock
    {
        string Block { get; set; }
        string N_trans { get; set; }
        string Output_Total { get; set; }
        string Estimated_Transaction_Volume { get; set; }
        string Transaction_Fees { get; set; }
        IBlockHeight Height { get; set; }
        string Timestamp { get; set; }
        string Received_Time { get; set; }
        string Relayed_By { get; set; }
        string Difficulty { get; set; }
        string Bits { get; set; }
        string Size { get; set; }
        string Weight { get; set; }
        string Version { get; set; }
        string Nonce { get; set; }
        string Block_Reward { get; set; }
    }
}
