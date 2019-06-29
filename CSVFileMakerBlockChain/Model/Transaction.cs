using CSVFileMakerBlockChain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Model
{
    public class Transaction : ITransaction
    {
        public Transaction(ICollection<ISenderReciever> _senders, ICollection<ISenderReciever> _recievers)
        {
            Senders = _senders;
            Receivers = _recievers;
            //Senders = new List<ISenderReciever>();
            //Receivers = new List<ISenderReciever>();
        }

        public IBlock Block { get; set; }
        public ICollection<ISenderReciever> Senders { get; set; }
        public ICollection<ISenderReciever> Receivers { get; set; }
        public string Change { get; set; }
        public string Size { get; set; }
        public string Fee { get; set; }
        public string TransactionID { get; set; }
        
    }
}
