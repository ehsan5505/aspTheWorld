
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheWorld.Models
{
    class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger _logger;

        public WorldRepository(WorldContext context,ILogger<WorldRepository> logger)
        {
            _context    = context;
            _logger     = logger;
        }

        public void Add(Trip newTrip)
        {
            // add the trip to the db
            _context.Add(newTrip);
        }

        public void AddStop(string tripName,Stop newStop)
        {
            //get the trip
            var newtrip = getTripByName(tripName);
            // add 1 to the order to get the max
            if (newtrip.Stops.Count>0) {
                newStop.Order = newtrip.Stops.Max(s => s.Order) + 1;
            }
            else
            {
                newStop.Order = 1;
            }
            //now add to the database
            newtrip.Stops.Add(newStop);
        }

        public void AddStop(string tripName,string name,Stop newStop)
        {
            //get the trip
            var newtrip = getTripByName(tripName,name);
            // add 1 to the order to get the max
            if (newtrip.Stops.Count > 0)
            {
                newStop.Order = newtrip.Stops.Max(s => s.Order) + 1;
            }
            else
            {
                newStop.Order = 1;
            }
            //now add to the database
            newtrip.Stops.Add(newStop);
        }

        public IEnumerable<Trip> getAllTrips()
        {
            try
            {
                return _context.Trips.OrderBy(t => t.Name).ToList();
            }catch(Exception ex)
            {
                _logger.LogError("Error in the database handling : " + ex);
                return null;
            }
        }

        public IEnumerable<Trip> getAllTripsForUser(string name)
        {
            try
            {
                return _context.Trips
                    .Where(t => t.UserName == name)
                    .OrderBy(t => t.Name)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in the database handling : " + ex);
                return null;
            }
        }
        

        public IEnumerable<Trip> getAllTripsWithStop()
        {
            try
            {
                return _context.Trips
                    .Include(t => t.Stops)
                    .OrderBy(t => t.Name)
                    .ToList();

            }catch(Exception ex)
            {
                _logger.LogError("Error in the handling of the database: " + ex);
                return null;
            }
        }

        public Trip getTripByName(string tripName)
        {
            return _context.Trips.
                    Include(t => t.Stops)
                    .Where(t => t.Name == tripName)
                    .FirstOrDefault();
        }

        public Trip getTripByName(string tripName,string name)
        {
            return _context.Trips.
                    Include(t => t.Stops)
                    .Where(t => t.Name == tripName && t.UserName==name)
                    .FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}