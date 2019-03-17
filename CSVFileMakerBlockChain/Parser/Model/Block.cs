using CSVFileMakerBlockChain.Parser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Parser.Model
{
    public class Block : IBlock
    {
        public Block()
        {
        }

        public Block(string n_trans, string output_Total, string estimated_Transaction_Volume, string transaction_Fees, string height, string timestamp, string received_Time, string relayed_By, string difficulty, string bits, string size, string weight, string version, string nonce, string block_Reward)
        {
            N_trans = n_trans ?? throw new ArgumentNullException(nameof(n_trans));
            Output_Total = output_Total ?? throw new ArgumentNullException(nameof(output_Total));
            Estimated_Transaction_Volume = estimated_Transaction_Volume ?? throw new ArgumentNullException(nameof(estimated_Transaction_Volume));
            Transaction_Fees = transaction_Fees ?? throw new ArgumentNullException(nameof(transaction_Fees));
            Height = height ?? throw new ArgumentNullException(nameof(height));
            Timestamp = timestamp ?? throw new ArgumentNullException(nameof(timestamp));
            Received_Time = received_Time ?? throw new ArgumentNullException(nameof(received_Time));
            Relayed_By = relayed_By ?? throw new ArgumentNullException(nameof(relayed_By));
            Difficulty = difficulty ?? throw new ArgumentNullException(nameof(difficulty));
            Bits = bits ?? throw new ArgumentNullException(nameof(bits));
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Weight = weight ?? throw new ArgumentNullException(nameof(weight));
            Version = version ?? throw new ArgumentNullException(nameof(version));
            Nonce = nonce ?? throw new ArgumentNullException(nameof(nonce));
            Block_Reward = block_Reward ?? throw new ArgumentNullException(nameof(block_Reward));
        }

        public string N_trans { get; set; }
        public string Output_Total { get; set; }
        public string Estimated_Transaction_Volume { get; set; }
        public string Transaction_Fees { get; set; }
        public string Height { get; set; }
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
        string IBlock.Block { get; set; }
    }
}
