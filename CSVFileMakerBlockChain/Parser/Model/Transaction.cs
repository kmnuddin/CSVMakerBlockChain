using CSVFileMakerBlockChain.Parser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Parser.Model
{
    public class Transaction : ITransaction
    {
        public Transaction()
        {
        }

        public Transaction(IBlock block, IEnumerable<string> senders, IEnumerable<string> sending_Amounts, IEnumerable<string> receivers, IEnumerable<string> received_Amounts, string change, string size, string fee)
        {
            Block = block ?? throw new ArgumentNullException(nameof(block));
            Senders = senders ?? throw new ArgumentNullException(nameof(senders));
            Sending_Amounts = sending_Amounts ?? throw new ArgumentNullException(nameof(sending_Amounts));
            Receivers = receivers ?? throw new ArgumentNullException(nameof(receivers));
            Received_Amounts = received_Amounts ?? throw new ArgumentNullException(nameof(received_Amounts));
            Change = change ?? throw new ArgumentNullException(nameof(change));
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Fee = fee ?? throw new ArgumentNullException(nameof(fee));
        }

        public IBlock Block { get ; set ; }
        public IEnumerable<string> Senders { get ; set ; }
        public IEnumerable<string> Sending_Amounts { get ; set ; }
        public IEnumerable<string> Receivers { get ; set ; }
        public IEnumerable<string> Received_Amounts { get ; set ; }
        public string Change { get ; set ; }
        public string Size { get ; set ; }
        public string Fee { get ; set ; }
        string ITransaction.Transaction { get ; set ; }
    }
}
