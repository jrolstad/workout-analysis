using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mapmyfitnessapi_sdk.models;
using mapmyfitnessapi_sdk.services;
using mapmyfitnessapi_sdk.workouts;
using workout_analysis.mvc.Models;

namespace workout_analysis.mvc.Controllers
{
    public class WorkoutController : Controller
    {
        // GET: Workout
        public ActionResult Index(WorkoutIndexViewModel requestingModel)
        {
            var client = new WorkoutClient();

            var request = new WorkoutApiRequest();

            if (requestingModel.SearchRequest != null && !string.IsNullOrWhiteSpace(requestingModel.SearchRequest.StartedAfter))
            {
                request.WithStartedAfter(DateTime.Parse(requestingModel.SearchRequest.StartedAfter));
            }

            if (requestingModel.SearchRequest != null && !string.IsNullOrWhiteSpace(requestingModel.SearchRequest.UserId))
            {
                request.WithUserId(int.Parse(requestingModel.SearchRequest.UserId));
            }

            if (!string.IsNullOrWhiteSpace(requestingModel.ApiKey))
            {
                request.WithApiKey(requestingModel.ApiKey);
            }

            if (!string.IsNullOrWhiteSpace(requestingModel.AccessToken))
            {
                request.WithAccessToken(requestingModel.AccessToken);
            }

            var workouts = new List<Workout>();
            if (request.ApiKey != null && request.AccessToken != null)
            {
                workouts = client.Get(request);
            }

            var indexViewModel = new WorkoutIndexViewModel
            {
                AccessToken = requestingModel.AccessToken,
                ApiKey = requestingModel.ApiKey,
                SearchRequest = requestingModel.SearchRequest ?? new WorkoutSearchRequest(),
                Workouts = workouts.OrderByDescending(w => w.UpdatedDateTime).ToList()
            };
            return View(indexViewModel);
        }
    }
}