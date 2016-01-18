
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using TheWorld.ModelView;
using TheWorld.Services;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;

namespace TheWorld.Models
{
    [Authorize]
    [Route("api/trips/{tripName}/stops")]
    public class StopController :Controller
    {
        private CoodinateServiceResult _cordinate;
        private ILogger<StopController> _logger;
        private IWorldRepository _repository;

        public StopController(IWorldRepository repository,CoodinateServiceResult cordinate,ILogger<StopController> logger)
        {
            _repository = repository;
            _logger = logger;
            _cordinate = cordinate;
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

        [HttpPost("")]
        public async Task<JsonResult> Post(string tripName,[FromBody]StopModelView vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // map the stop
                    var newStop = Mapper.Map<Stop>(vm);
                    // get the co-ordinates
                    var cordinateResult = await _cordinate.Lookup(newStop.Name);

                    if (!cordinateResult.Status)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return Json(new { Message="Error in the finding of coordinates"});
                    }

                    newStop.Longitude = cordinateResult.Longitude;
                    newStop.Latitude = cordinateResult.Latitude;
                    // dump the data to the database
                    _repository.AddStop(tripName,newStop);
                    if (_repository.SaveAll())
                    {
                        return Json(Mapper.Map<StopModelView>(newStop));
                    }
                }
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = "Error in the posting of data ", Error = ModelState });

            }
            catch(Exception ex)
            {
                _logger.LogError("Error in the posting of data " + ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = "Error in the posting of data ", Error = ex }); 
            };


        }
          
    }
}