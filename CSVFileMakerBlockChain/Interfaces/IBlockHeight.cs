﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain.Interfaces
{
    public interface IBlockHeight
    {
        string Height { get; set; }
        string Hash { get; set; }
    }
}
