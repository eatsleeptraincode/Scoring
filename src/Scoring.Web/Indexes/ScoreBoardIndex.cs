using System.Linq;
using Raven.Client.Indexes;
using Scoring.Web.Models;

namespace Scoring.Web.Indexes
{
    public class ScoreBoardIndex : AbstractIndexCreationTask<Score>
    {
        public ScoreBoardIndex()
        {
            Map =
                scores => from score in scores
                          select new
                          {
                              score.EventId,
                              score.AthleteId,
                              score.Time,
                              score.Reps,
                              score.Gender,
                              score.ScoreType
                          };

            TransformResults =
                (database, scores) => from score in scores
                                      let theEvent = database.Load<Event>(score.EventId)
                                      let athlete = database.Load<Athlete>(score.AthleteId)
                                      select new
                                      {
                                          Event = theEvent,
                                          Athlete = athlete,
                                          score.Id,
                                          score.AthleteId,
                                          score.Time,
                                          score.Reps,
                                          score.Place,
                                          score.Gender,
                                          score.ScoreType
                                      };
        }
    }
}