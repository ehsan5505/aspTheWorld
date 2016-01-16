
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace TheWorld.Models
{
    class WorldRepository : IWorldRepository
    {
        private WorldContext _context;

        public WorldRepository(WorldContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Trip> getAllTrips()
        {
            return _context.Trips.OrderBy(t => t.Name).ToList();
        }

        public IEnumerable<Trip> getAlTripsWithStop()
        {
            return _context.Trips
                .Include(t => t.Stops)
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}