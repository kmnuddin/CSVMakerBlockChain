using CSVFileMakerBlockChain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Model
{
    public class Block : IBlock
    {
        public Block()
        {
        }

        public string N_trans { get; set; }
        public string Output_Total { get; set; }
        public string Estimated_Transaction_Volume { get; set; }
        public string Transaction_Fees { get; set; }
        public string Timestamp { get; set; }
        public string Received_Time { get; set; }
        public string Relayed_By { get; set; }
        public string Difficulty { get; set; }
        public string Bits { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string Version { get; set; }
        public string Nonce { get; set; }
        public string Block_Reward { get; set; }
        public IBlockHeight Height { get; set; }
        public IEnumerable<ITransaction> Transactions { get; set; }
        string IBlock.Block { get; set; }
        
    }
}
