using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CSVFileMakerBlockChain.Interfaces;
using CSVFileMakerBlockChain.Model;
using CSVFileMakerBlockChain.Repository;
using CSVFileMakerBlockChain.View_Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSVFileMakerBlockChain.WindsorInstaller
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            
            container
                .Register(Component.For<IBlockHeight>().ImplementedBy<BlockHeight>().LifestyleTransient())
                .Register(Component.For<IBlock>().ImplementedBy<Block>().LifestyleTransient())
                .Register(Component.For<ITransaction>().ImplementedBy<Transaction>().LifestyleTransient())
                .Register(Component.For<ISenderReciever>().ImplementedBy<SenderReciever>().LifestyleTransient())
                .Register(Component.For<IParserFactory>().ImplementedBy<ParserFactory>().LifestyleTransient())
                .Register(Component.For<IWebRepository>().ImplementedBy<WebRepository>().LifestyleSingleton())
                .Register(Component.For<IViewModel>().ImplementedBy<ViewModel>().LifestyleSingleton())
                .Register(Component.For<HtmlNode>().LifestyleTransient())
                .Register(Component.For<HtmlWeb>().LifestyleSingleton());

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
        }
    }
}
