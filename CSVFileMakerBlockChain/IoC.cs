using Castle.Windsor;
using Castle.Windsor.Installer;
using CSVFileMakerBlockChain.WindsorInstaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileMakerBlockChain
{
    public static class IoC
    {
        public static IWindsorContainer GlobalContainer = new WindsorContainer();

        public static void BootstrapContainer()
        {
            GlobalContainer =  GlobalContainer.Install(new Installer());
        }

        
    }
}
