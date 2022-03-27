using System.Collections.Generic;
using Application.Domain;

namespace Application.Repository
{
    public interface ITripRepo
    {
        public void Save(Trip trip);
        public void Delete(Trip trip);
        public Trip GetById(int id);
        public List<Trip> GetTripsFiltered(string destination = "", string departureLocation = "");
    }
}
