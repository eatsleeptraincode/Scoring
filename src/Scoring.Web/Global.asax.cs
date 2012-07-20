using System;
using System.Web;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using Scoring.Web.Config;
using StructureMap;

namespace Scoring.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            FubuApplication
                .For<ConfigureFubuMvc>()
                .StructureMap(new Container(c => c.AddRegistry<ConfigureStructureMap>()))
                .Bootstrap();
        }
    }
}