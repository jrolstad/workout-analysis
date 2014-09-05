namespace workout_analysis.mvc.Models
{
    public class WorkoutSearchRequest
    {
        public string StartedAfter { get; set; }

        public string ApiKey { get; set; }

        public string AccessToken { get; set; }
    }
}