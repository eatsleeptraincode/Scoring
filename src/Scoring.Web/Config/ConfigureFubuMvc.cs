using System;
using FubuMVC.Core;
using FubuMVC.Core.Security.AntiForgery;
using Scoring.Web.Actions;
using Scoring.Web.Actions.Scores;
using Scoring.Web.Behaviours;
using Scoring.Web.Security;

namespace Scoring.Web.Config
{
    public class ConfigureFubuMvc : FubuRegistry
    {
        public ConfigureFubuMvc()
        {
            Applies.ToThisAssembly();

            Actions.IncludeTypesNamed(t => t.EndsWith("Action"));

            Routes
                .HomeIs<LeaderBoardRequest>()
                .IgnoreNamespaceForUrlFrom<UrlRoot>()
                .IgnoreClassSuffix("Action")
                .IgnoreMethodsNamed("Get")
                .IgnoreMethodsNamed("Post")
                .ConstrainToHttpMethod(c => c.Method.Name.Equals("Get"), "GET")
                .ConstrainToHttpMethod(c => c.Method.Name.Equals("Post"), "POST");

            StringConversions(s => s.IfIsType<DateTime>().ConvertBy(d => d.ToShortTimeString()));

            HtmlConvention<ConfigureHtml>();

            Views.TryToAttachWithDefaultConventions();

            Policies
                .Add<AntiForgeryPolicy>()
                .Add<AttachAuthenticationPolicy>()
                .WrapBehaviorChainsWith<RavenTransactionBehaviour>();

        }
    }
}