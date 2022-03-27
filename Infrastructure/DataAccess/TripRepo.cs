using System;
using System.Collections.Generic;
using Application.Domain;
using Application.Repository;

namespace Infrastructure.DataAccess
{
    class TripRepo : ITripRepo
    {
        public void Delete(Trip trip)
        {
            throw new NotImplementedException();
        }

        public Trip GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Trip> GetTripsFiltered(string destination = "", string departureLocation = "")
        {
            throw new NotImplementedException();
        }

        public void Save(Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}
