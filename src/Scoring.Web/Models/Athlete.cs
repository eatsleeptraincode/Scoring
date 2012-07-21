namespace Scoring.Web.Models
{
    public class Athlete : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}