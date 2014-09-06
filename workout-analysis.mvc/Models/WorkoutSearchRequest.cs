namespace workout_analysis.mvc.Models
{
    public class WorkoutSearchRequest
    {
        public string StartedAfter { get; set; }

        public string UserId { get; set; }

        public string SearchTerms { get; set; }
       
    }
}