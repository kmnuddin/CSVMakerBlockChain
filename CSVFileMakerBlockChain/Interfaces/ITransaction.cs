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
        ICollection<ISenderReciever> Senders { get; set; }
        ICollection<ISenderReciever> Receivers { get; set; }
        string Change { get; set; }
        string Size { get; set; }
        string Fee { get; set; }
    }
}
