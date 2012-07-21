using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using Scoring.Web.Actions.Scores;
using Scoring.Web.Security;

namespace Scoring.Web.Actions.Accounts
{
    public class LoginAction
    {
        private readonly IAuthenticationContext authContext;
        private readonly IEncryptor encryptor;

        public LoginAction(IAuthenticationContext authContext, IEncryptor encryptor)
        {
            this.authContext = authContext;
            this.encryptor = encryptor;
        }

        public LoginViewModel Get(LoginRequest request)
        {
            return new LoginViewModel();
        }

        public FubuContinuation Post(LoginViewModel request)
        {
            var encrypt = encryptor.Encrypt(request.Passcode);
            if (encrypt == "yODpjQnGBLJnIGxbIzXj7w==")
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