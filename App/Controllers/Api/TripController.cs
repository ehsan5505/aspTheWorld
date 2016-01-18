using System;
using Microsoft.AspNet.Mvc;
using System.Net;
using TheWorld.ModelView;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Authorization;

namespace TheWorld.Models
{

    [Authorize]
    [Route("/api/trips")]
    public class TripController : Controller
    {
        private IWorldRepository _repository;
        public ILogger _logger;

        public TripController(IWorldRepository repository,ILogger<TripController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try {
                //var results = _repository.getAlTripsWithStop();
                var results = _repository.getAllTripsForUser(User.Identity.Name);
                var mapper = Mapper.Map<IList<TripModelView>>(results);
                return Json(mapper);
            }catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                _logger.LogError("Error in the get api/trips service may be arise due to the mapping, here is the detail info : " + ex);
                return Json(new { Message = "Error may be in the mapper", Error = ex });

            }
        }

        [HttpPost("")]
        public JsonResult PostingTheData([FromBody]TripModelView data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTrip = Mapper.Map<Trip>(data);
                    Response.StatusCode = (int)HttpStatusCode.Created;

                    newTrip.UserName = User.Identity.Name; // adding the username
                    
                    //save the data(trip) to the database
                    _logger.LogInformation("Attempting to save " + data.Name + " in the database");
                    _repository.Add(newTrip);

                    if (_repository.SaveAll())
                    {
                        _logger.LogInformation("Successfully add the trip " + newTrip.Name + " in to the database");
                        return Json(Mapper.Map<TripModelView>(newTrip));
                    }
                }

                // in case if data is not valid then do the following
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError("Error occur may be due to the model Invalidation, pleae check the log for full trace : " + ModelState);
                return Json(new { Message = "Invalid data", ErrorProne = ModelState });
            }catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                _logger.LogError("Error occur in the post api/trips service may be mapping, for trace error view the detail: " + ex);
                return Json(new { Message = "Error occur in the mapping", Error = ex });
            }
        }
    }
}
