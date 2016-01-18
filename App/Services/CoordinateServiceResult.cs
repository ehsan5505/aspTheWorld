using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace TheWorld.Services
{
    public class CoodinateServiceResult
    {
        private ILogger<CoodinateServiceResult> _logger;
        

        public CoodinateServiceResult(ILogger<CoodinateServiceResult> logger)
        {
            _logger = logger;
        }

        public async Task<CoordinateService> Lookup(string location)
        {
            var cord = new CoordinateService()
            {
                Status = false,
                Message = "Unable to find the location : " + location
            };

            //here comes the logic
            //var url = "http://www.gps-coordinates.net/api/eiffeltowe";
            
            var url = $"http://maps.googleapis.com/maps/api/geocode/json?address={location.ToLower()}&sensor=false";

            var client = new System.Net.Http.HttpClient();
            var json = await client.GetStringAsync(url);
            var result = JObject.Parse(json);
            var resources = result["results"][0]["geometry"]["location"];
            var status = (string)result["status"];
            var lng = (string)resources["lng"];
            var lat = (string)resources["lat"];
            if (status == "OK")
            {
                cord.Latitude = Double.Parse(lat);
                cord.Longitude = Double.Parse(lng);
                cord.Status = true;
                cord.Message = "Co-ordinate have been found";
            }
            //cord.Longitude = (double)resources["lng"];

            return cord;
        }
    }
}
