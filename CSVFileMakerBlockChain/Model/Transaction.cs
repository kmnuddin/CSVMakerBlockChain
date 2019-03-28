using CSVFileMakerBlockChain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Model
{
    public class Transaction : ITransaction
    {
        public Transaction()
        {

        }

        public IBlock Block { get; set; }
        public IEnumerable<string> Senders { get; set; }
        public IEnumerable<string> Sending_Amounts { get; set; }
        public IEnumerable<string> Receivers { get; set; }
        public IEnumerable<string> Received_Amounts { get; set; }
        public string Change { get; set; }
        public string Size { get; set; }
        public string Fee { get; set; }
        public string TransactionID { get; set; }
    }
}
