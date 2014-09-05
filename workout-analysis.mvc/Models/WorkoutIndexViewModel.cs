using System.Collections.Generic;
using mapmyfitnessapi_sdk.models;

namespace workout_analysis.mvc.Models
{
    public class WorkoutIndexViewModel
    {
        public string ApiKey { get; set; }

        public string AccessToken { get; set; }

        public WorkoutSearchRequest SearchRequest { get; set; }

        public List<Workout> Workouts { get; set; } 
    }
}