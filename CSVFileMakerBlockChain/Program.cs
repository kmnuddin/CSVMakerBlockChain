using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CSVFileMakerBlockChain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVFileMakerBlockChain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IoC.BootstrapContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(IoC.GlobalContainer.Resolve<IViewModel>()));
        }

        
    }
}
