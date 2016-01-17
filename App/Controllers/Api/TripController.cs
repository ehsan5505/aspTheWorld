using System;
using Microsoft.AspNet.Mvc;
using System.Net;

namespace TheWorld.Models
{
    [Route("/api/trips")]
    public class TripController : Controller
    {
        private IWorldRepository _repository;

        public TripController(IWorldRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            return Json(_repository.getAlTripsWithStop());
        }

        [HttpPost("")]
        public JsonResult PostingTheData([FromBody]Trip data)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(true);
            }

            // in case if data is not valid then do the following
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Invalid data" });
        }
    }
}
