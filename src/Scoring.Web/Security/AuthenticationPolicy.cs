using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;

namespace Scoring.Web.Security
{
    public class AuthenticationPolicy : IAuthorizationPolicy
    {
        private readonly ISecurityContext secContext;

        public AuthenticationPolicy(ISecurityContext secContext)
        {
            this.secContext = secContext;
        }

        public AuthorizationRight RightsFor(IFubuRequest request)
        {
            if (secContext.IsAuthenticated())
                return AuthorizationRight.Allow;
            return AuthorizationRight.Deny;
        }
    }
}