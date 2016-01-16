using System.Collections.Generic;

namespace TheWorld.Models
{
    interface IWorldRepository
    {
        IEnumerable<Trip> getAllTrips();
        IEnumerable<Trip> getAlTripsWithStop();
    }
}