
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

        public IEnumerable<Trip> getAlTripsWithStop()
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

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}