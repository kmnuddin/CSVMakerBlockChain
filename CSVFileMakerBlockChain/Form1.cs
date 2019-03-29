
using CSVFileMakerBlockChain.Interfaces;
using CSVFileMakerBlockChain.Properties;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVFileMakerBlockChain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var test = IoC.GlobalContainer.Resolve<IWebRepository>();

            Console.WriteLine(test.ParseBlockHeights(565578, 565578).Count());
        }

        
    }
}
