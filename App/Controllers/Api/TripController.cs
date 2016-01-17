using System;
using Microsoft.AspNet.Mvc;

namespace TheWorld.Models
{
    public class TripController : Controller
    {
        [HttpGet("/api/trips")]
        public JsonResult Get()
        {
            return Json(new { name = "Ehsan Rafeeque" });
        }
    }
}
