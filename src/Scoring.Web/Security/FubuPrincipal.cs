using System.Security.Principal;
using System.Threading;
using System.Web;

namespace Scoring.Web.Security
{
    public class FubuPrincipal : IPrincipal
    {
        private readonly IIdentity identity;

        public FubuPrincipal(IIdentity identity)
        {
            this.identity = identity;
        }

        public static FubuPrincipal Current
        {
            get {
                var principal =  HttpContext.Current != null
                    ? HttpContext.Current.User
                    : Thread.CurrentPrincipal;
                return principal as FubuPrincipal;
            }
        }

        public bool IsInRole(string role) { return true; }
        public IIdentity Identity { get { return identity; } }
    }
}