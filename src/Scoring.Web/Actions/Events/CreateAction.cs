using FubuMVC.Core.Continuations;
using Raven.Client;
using Scoring.Web.Models;

namespace Scoring.Web.Actions.Events
{
    public class CreateAction
    {
        private readonly IDocumentSession session;

        public CreateAction(IDocumentSession session)
        {
            this.session = session;
        }

        public CreateEventViewModel Get(CreateEventRequest request)
        {
            return new CreateEventViewModel();
        }

        public FubuContinuation Post(CreateEventViewModel request)
        {
            session.Store(request.Event);
            return FubuContinuation.RedirectTo(new EventListRequest());
        }
    }

    public class CreateEventRequest
    {
    }

    public class CreateEventViewModel
    {
        public Event Event { get; set; }
    }
}