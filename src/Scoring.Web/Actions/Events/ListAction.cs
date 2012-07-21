using System.Collections.Generic;
using Raven.Client;
using Raven.Client.Linq;
using Scoring.Web.Models;

namespace Scoring.Web.Actions.Events
{
    public class ListAction
    {
        private readonly IDocumentSession session;

        public ListAction(IDocumentSession session)
        {
            this.session = session;
        }

        public EventListViewModel Get(EventListRequest request)
        {
            var events = session.Query<Event>().OrderBy(e => e.Number);
            return new EventListViewModel {Events = events};
        }
    }

    public class EventListRequest
    {
    }

    public class EventListViewModel
    {
        public IEnumerable<Event> Events { get; set; }
    }
}