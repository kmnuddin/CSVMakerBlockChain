using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Interfaces
{
    public interface ITransaction
    {
        IBlock Block { get; set; }
        string TransactionID { get; set; }
        IEnumerable<string> Senders { get; set; }
        IEnumerable<string> Sending_Amounts { get; set; }
        IEnumerable<string> Receivers { get; set; }
        IEnumerable<string> Received_Amounts { get; set; }
        string Change { get; set; }
        string Size { get; set; }
        string Fee { get; set; }
    }
}
