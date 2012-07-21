using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using Scoring.Web.Actions.Scores;

namespace Scoring.Web.Actions.Accounts
{
    public class LoginAction
    {
        private readonly IAuthenticationContext authContext;

        public LoginAction(IAuthenticationContext authContext)
        {
            this.authContext = authContext;
        }

        public LoginViewModel Get(LoginRequest request)
        {
            return new LoginViewModel();
        }

        public FubuContinuation Post(LoginViewModel request)
        {
            if (request.Passcode == "admin")
                authContext.ThisUserHasBeenAuthenticated("admin", true);
            return FubuContinuation.RedirectTo(new LeaderBoardRequest());
        }
    }

    public class LoginRequest
    {
    }

    public class LoginViewModel
    {
        public string Passcode { get; set; }
    }
}