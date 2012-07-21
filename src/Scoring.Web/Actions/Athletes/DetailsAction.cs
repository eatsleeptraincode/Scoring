using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core;
using Raven.Client;
using Raven.Client.Linq;
using Scoring.Web.Indexes;
using Scoring.Web.Models;

namespace Scoring.Web.Actions.Athletes
{
    public class DetailsAction
    {
        private readonly IDocumentSession session;

        public DetailsAction(IDocumentSession session)
        {
            this.session = session;
        }

        public AthleteDetailsViewModel Get(AthleteDetailsRequest request)
        {
            var athlete = session.Load<Athlete>(request.AthleteId);
            var scores = session.Query<Score,ScoreBoardIndex>().As<ScoreDisplay>().Where(a => a.AthleteId == athlete.Id);
            return new AthleteDetailsViewModel {Athlete = athlete, Scores = scores};
        }
    }

    public class AthleteDetailsRequest
    {
        [RouteInput]
        public string AthleteId { get; set; }
    }

    public class AthleteDetailsViewModel
    {
        public Athlete Athlete { get; set; }
        public IEnumerable<ScoreDisplay> Scores { get; set; }
    }
}