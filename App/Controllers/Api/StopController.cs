
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using TheWorld.ModelView;
namespace TheWorld.Models
{
    [Route("api/trips/{tripName}/stops")]
    public class StopController :Controller
    {
        private ILogger<StopController> _logger;
        private IWorldRepository _repository;

        public StopController(IWorldRepository repository,ILogger<StopController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult getTheStop(string tripName)
        {
            try
            {
                var result = _repository.getTripByName(tripName);
                var mapper = Mapper.Map<IList<StopModelView>>(result.Stops);
                if (result == null)
                {
                    return Json(new { Message = "There is no data" });
                }
               
                return Json(mapper);
            } catch (Exception ex)
            {
                _logger.LogError("Error in the getStops " + ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = "Bad Request Error"});
            }
            //return Json(new { Messsage = tripName });
        }
          
    }
}