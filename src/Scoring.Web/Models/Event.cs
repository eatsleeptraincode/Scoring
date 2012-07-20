using System;

namespace Scoring.Web.Models
{
    public class Event : Entity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
    }
}