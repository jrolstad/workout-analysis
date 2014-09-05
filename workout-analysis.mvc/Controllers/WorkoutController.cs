using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mapmyfitnessapi_sdk.services;
using mapmyfitnessapi_sdk.workouts;
using workout_analysis.mvc.Models;

namespace workout_analysis.mvc.Controllers
{
    public class WorkoutController : Controller
    {
        // GET: Workout
        public ActionResult Index(WorkoutSearchRequest searchParameters)
        {
            var client = new WorkoutClient();

            var request = new WorkoutApiRequest();
            request.WithUserId(502434);

            if (searchParameters != null && !string.IsNullOrWhiteSpace(searchParameters.StartedAfter))
            {
                request.WithStartedAfter(DateTime.Parse(searchParameters.StartedAfter));
            }

            if (searchParameters != null && !string.IsNullOrWhiteSpace(searchParameters.ApiKey))
            {
                request.WithApiKey(searchParameters.ApiKey);
            }

            if (searchParameters != null && !string.IsNullOrWhiteSpace(searchParameters.AccessToken))
            {
                request.WithAccessToken(searchParameters.AccessToken);
            }

            request
                .WithApiKey("z8w3jv4y9b2nhq5qjgzb9pmpt4pwg9mc")
                .WithAccessToken("0834ab313a742d2e5028a6b28351fa0673d852f5")
                ;
            var workouts = client.Get(request);
            var sortedWorkouts = workouts.OrderByDescending(w => w.UpdatedDateTime);

            return View(sortedWorkouts);
        }
    }
}