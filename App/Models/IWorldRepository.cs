using System.Collections.Generic;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> getAllTrips();
        IEnumerable<Trip> getAlTripsWithStop();
        bool SaveAll();
        void Add(Trip newTrip);
    }
}