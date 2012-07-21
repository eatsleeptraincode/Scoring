using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core.Registration;
using Scoring.Web.Actions.Scores;

namespace Scoring.Web.Security
{
    public class AttachAuthenticationPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph
                .Behaviors
                .Where(chain => chain.InputType() != null)
                .Where(chain => chain.InputType() == typeof (LogScoreRequest))
                .Each(chain => chain
                                   .Authorization
                                   .AddPolicy(typeof (AuthenticationPolicy)));
        }
    }
}