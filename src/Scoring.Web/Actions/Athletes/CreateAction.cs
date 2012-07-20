using FubuMVC.Core.Continuations;
using Raven.Client;
using Scoring.Web.Models;

namespace Scoring.Web.Actions.Athletes
{
    public class CreateAction
    {
        private readonly IDocumentSession session;

        public CreateAction(IDocumentSession session)
        {
            this.session = session;
        }

        public CreateAthleteViewModel Get(CreateAthleteRequest request)
        {
            return new CreateAthleteViewModel();
        }

        public FubuContinuation Post(CreateAthleteViewModel request)
        {
            session.Store(request.Athlete);
            return FubuContinuation.RedirectTo(new AthleteListRequest());
        }
    }

    public class CreateAthleteRequest
    {
    }

    public class CreateAthleteViewModel
    {
        public Athlete Athlete { get; set; }
    }
}