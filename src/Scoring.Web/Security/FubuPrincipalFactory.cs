using System.Linq;
using System.Security.Principal;
using FubuMVC.Core.Security;
using Raven.Client;
using Scoring.Web.Models;

namespace Scoring.Web.Security
{
    public class FubuPrincipalFactory : IPrincipalFactory
    {
        readonly IDocumentSession session;

        public FubuPrincipalFactory(IDocumentSession session)
        {
            this.session = session;
        }

        public IPrincipal CreatePrincipal(IIdentity identity)
        {
            return FubuPrincipal.Current
                ?? new FubuPrincipal(identity);
        }
    }
}