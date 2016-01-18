using System.Collections.Generic;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> getAllTrips();
        IEnumerable<Trip> getAlTripsWithStop();
        bool SaveAll();
        void Add(Trip newTrip);
        Trip getTripByName(string tripName);
        void AddStop(string tripName,Stop newStop);
        IEnumerable<Trip> getAllTripsForUser(string name);
        Trip getTripByName(string tripName, string name);
        void AddStop(string tripName, string name, Stop newStop);
    }
}