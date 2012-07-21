namespace Scoring.Web.Models
{
    public class Score : Entity
    {
        public Score()
        {
            Time = new Time();
        }

        public string AthleteName { get; set; }
        public string AthleteId { get; set; }
        public string EventId { get; set; }
        public Gender Gender { get; set; }
        public ScoreType ScoreType { get; set; }

        public int Place { get; set; }
        public int Reps { get; set; }
        public Time Time { get; set; }
    }

    public class ScoreDisplay : Score
    {
        public Athlete Athlete { get; set; }
        public Event Event { get; set; }
    }

    public class Time
    {
        public decimal Minutes { get; set; }
        public decimal Seconds { get; set; }

        public bool IsBetterThan(Time time)
        {
            return Minutes < time.Minutes
                || Minutes == time.Minutes && Seconds < time.Seconds;
        }
    }

}