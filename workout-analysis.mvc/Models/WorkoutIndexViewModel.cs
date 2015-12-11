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

    public static class WorkoutExtensions
    {
        public static double? DistanceInMiles(this Workout workout)
        {
            const double metersPerMile = 1609.34;

            if (!workout.Distance.HasValue) return null;

            return workout.Distance/metersPerMile;
        }

        public static string ActivityTypeName(this Workout workout)
        {
            switch (workout.ActivityType)
            {
                case 172:
                case 197:
                case 16: 
                case 136: 
                case 187: 
                    return "Run";
                case 11:
                    return "Bike";
                case 75:
                    return "Swim";
                 case 24:
                 case 510:
                 case 109:
                    return "Hike";
                default:
                    return workout.ActivityType.ToString();
            }
            return workout.ActivityType.ToString();
        }

    }
}