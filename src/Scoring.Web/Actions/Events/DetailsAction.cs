using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core;
using Raven.Client;
using Raven.Client.Linq;
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
            var athletes = session.Query<Athlete>().ToList();
            var scores = session.Query<Score>().Where(s => s.EventId == request.EventId).ToList();

            var displays = new List<ScoreDisplay>();
            foreach (var athlete in athletes)
            {
                var display = new ScoreDisplay {Athlete = athlete, Event = theEvent};
                var score = scores.SingleOrDefault(s => s.AthleteId == athlete.Id);
                if (score != null)
                {
                    display.Place = score.Place;
                    display.Time = score.Time;
                    display.Reps = score.Reps;
                }else
                {
                    display.Place = 99;
                }

                displays.Add(display);
            }
            return new EventDetailsViewModel {Event = theEvent, Scores = displays};
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
        public IEnumerable<ScoreDisplay> Scores { get; set; }
    }
}