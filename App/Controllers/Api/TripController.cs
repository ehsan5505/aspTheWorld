using System;
using Microsoft.AspNet.Mvc;

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
    }
}
