using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Raven.Client.Linq;
using Scoring.Web.Indexes;
using Scoring.Web.Models;

namespace Scoring.Web.Actions.Scores
{
    public class LeaderBoardAction
    {
        private readonly IDocumentSession session;

        public LeaderBoardAction(IDocumentSession session)
        {
            this.session = session;
        }

        public LeaderBoardViewModel Get(LeaderBoardRequest request)
        {
            var scores = session
                .Query<Score, ScoreBoardIndex>()
                .As<ScoreDisplay>()
                .ToList()
                .GroupBy(s => s.Athlete.Id);

            return new LeaderBoardViewModel{Scores = scores.Select(score => new ScoreRow
                                       {
                                           Athlete = score.First().Athlete,
                                           Total = score.Sum(s => s.Place),
                                           Event1 = GetPlace(score, 1),
                                           Event2 = GetPlace(score, 2),
                                           Event3 = GetPlace(score, 3),
                                           Event4 = GetPlace(score, 4),
                                           Event5 = GetPlace(score, 5),
                                           Event6 = GetPlace(score, 6),
                                           Event7 = GetPlace(score, 7),
                                           Event8 = GetPlace(score, 8)
                                       })};
        }

        private static int? GetPlace(IEnumerable<ScoreDisplay> score, int eventNumber)
        {
            var display = score.SingleOrDefault(d => d.Event.Number == eventNumber);
            return display == null
                       ? (int?) null
                       : display.Place;
        }
    }

    public class LeaderBoardRequest
    {
    }

    public class LeaderBoardViewModel
    {
        public IEnumerable<ScoreRow> Scores { get; set; }
    }

    public class ScoreRow
    {
        public Athlete Athlete { get; set; }
        public int? Event1 { get; set; }
        public int? Event2 { get; set; }
        public int? Event3 { get; set; }
        public int? Event4 { get; set; }
        public int? Event5 { get; set; }
        public int? Event6 { get; set; }
        public int? Event7 { get; set; }
        public int? Event8 { get; set; }
        public int Total { get; set; }
    }
}