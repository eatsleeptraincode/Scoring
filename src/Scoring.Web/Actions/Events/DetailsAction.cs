using System.Collections.Generic;
using FubuMVC.Core;
using Raven.Client;
using Scoring.Web.Models;

namespace Scoring.Web.Actions.Events
{
    public class DetailsAction
    {
        private readonly IDocumentSession session;

        public DetailsAction(IDocumentSession session)
        {
            this.session = session;
        }

        public EventDetailsViewModel Get(EventDetailsRequest request)
        {
            var theEvent = session.Load<Event>(request.EventId);
            var athletes = session.Query<Athlete>();
            return new EventDetailsViewModel {Event = theEvent, Athletes = athletes};
        }
    }

    public class EventDetailsRequest
    {
        [RouteInput]
        public string EventId { get; set; }
    }

    public class EventDetailsViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<Athlete> Athletes { get; set; }
    }
}