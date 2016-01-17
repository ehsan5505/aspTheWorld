using System;
using Microsoft.AspNet.Mvc;

namespace TheWorld.Models
{
    public class TripController : Controller
    {
        private IWorldRepository _repository;

        public TripController(IWorldRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/api/trips")]
        public JsonResult Get()
        {
            return Json(_repository.getAlTripsWithStop());
        }
    }
}
