﻿using FubuMVC.Core.Security;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using StructureMap.Configuration.DSL;

namespace Scoring.Web.Config
{
    public class ConfigureStructureMap : Registry
    {
        public ConfigureStructureMap()
        {
            ForSingletonOf<IDocumentStore>()
                .Use(ctx =>
                {
                    var store = new DocumentStore
                    {
                        ConnectionStringName = "RavenDb",
                        Conventions = { IdentityPartsSeparator = "-" }
                    }.Initialize();
                    IndexCreation.CreateIndexes(typeof(ConfigureFubuMvc).Assembly, store);
                    return store;
                });

            For<IDocumentSession>()
                .Use(ctx => ctx.GetInstance<IDocumentStore>().OpenSession());
        }
    }
}