using CSVFileMakerBlockChain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Model
{
    public class SenderReciever : ISenderReciever
    {
        public SenderReciever()
        {

        }
        public string Hash { get; set; }
        public string Amount { get; set; }
    }
}
