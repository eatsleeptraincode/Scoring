using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using Scoring.Web.Actions.Scores;

namespace Scoring.Web.Actions.Accounts
{
    public class LogoutAction
    {
        private readonly IAuthenticationContext authContext;

        public LogoutAction(IAuthenticationContext authContext)
        {
            this.authContext = authContext;
        }

        public FubuContinuation Get(LogoutRequest request)
        {
            authContext.SignOut();
            return FubuContinuation.RedirectTo(new LeaderBoardRequest());
        }
    }

    public class LogoutRequest
    {
    }
}