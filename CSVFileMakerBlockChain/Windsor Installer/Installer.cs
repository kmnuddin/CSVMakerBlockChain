﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CSVFileMakerBlockChain.Interfaces;
using CSVFileMakerBlockChain.Model;
using CSVFileMakerBlockChain.Repository;
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
                .Register(Component.For<IParserFactory>().ImplementedBy<ParserFactory>().LifestyleTransient())
                .Register(Component.For<IWebRepository>().ImplementedBy<WebRepository>().LifestyleSingleton())
                .Register(Component.For<IEnumerable<HtmlNode>>().ImplementedBy<List<HtmlNode>>().LifestyleTransient())
                .Register(Component.For<IEnumerable<IBlock>>().ImplementedBy<List<IBlock>>().LifestyleTransient())
                .Register(Component.For<IEnumerable<IBlockHeight>>().ImplementedBy<List<IBlockHeight>>().LifestyleTransient())
                .Register(Component.For<IEnumerable<ITransaction>>().ImplementedBy<List<ITransaction>>().LifestyleTransient())
                .Register(Component.For<HtmlNode>().LifestyleTransient())
                .Register(Component.For<HtmlWeb>().LifestyleSingleton());
        }
    }
}
