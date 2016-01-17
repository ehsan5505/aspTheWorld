using System;
using Microsoft.AspNet.Mvc;
using System.Net;
using TheWorld.ModelView;
using AutoMapper;
using System.Collections.Generic;

namespace TheWorld.Models
{
    [Route("/api/trips")]
    public class TripController : Controller
    {
        private readonly TripModelView IEnumberable;
        private IWorldRepository _repository;

        public TripController(IWorldRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try {
                var results = _repository.getAlTripsWithStop();
                var mapper = Mapper.Map<IList<TripModelView>>(results);
                return Json(mapper);
            }catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
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
                    return Json(Mapper.Map<TripModelView>(newTrip));
                }

                // in case if data is not valid then do the following
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = "Invalid data", ErrorProne = ModelState });
            }catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                return Json(new { Message = "Error occur in the mapping", Error = ex });
            }
        }
    }
}
