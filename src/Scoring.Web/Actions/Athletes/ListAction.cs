using System.Collections.Generic;
using Raven.Client;
using Scoring.Web.Models;

namespace Scoring.Web.Actions.Athletes
{
    public class ListAction
    {
        private readonly IDocumentSession session;

        public ListAction(IDocumentSession session)
        {
            this.session = session;
        }

        public AthleteListViewModel Get(AthleteListRequest request)
        {
            var athletes = session.Query<Athlete>();
            return new AthleteListViewModel{Athletes = athletes};
        }
    }

    public class AthleteListRequest
    {
    }

    public class AthleteListViewModel
    {
        public IEnumerable<Athlete> Athletes { get; set; }
    }
}