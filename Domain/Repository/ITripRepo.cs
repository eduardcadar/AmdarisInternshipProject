using System.Collections.Generic;
using Domain.Domain;

namespace Domain.Repository
{
    public interface ITripRepo : IRepo<Trip, int>
    {
        public List<Trip> GetTripsFiltered(string destination = "", string departureLocation = "");
    }
}
