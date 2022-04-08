using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    public class TripDbRepo : ITripRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public TripDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(DTrip dTrip)
        {
            var trip = EntityUtils.DTripToTrip(dTrip);
            _dbContext.Trips.Remove(trip);
            _dbContext.SaveChanges();
        }

        public DTrip Get(int id)
        {
            var trip = _dbContext.Trips.Find(id);
            if (trip == null)
                throw new RepositoryException("There is no trip with this id");
            var dTrip = EntityUtils.TripToDTrip(trip);
            return dTrip;
        }

        public IEnumerable<DTrip> GetFiltered(string destination = "", string departureLocation = "")
        {
            var filteredTrips = _dbContext.Trips
                .Where(t => t.Destination.Contains(destination) && t.DepartureLocation.Contains(departureLocation));
            var dTrips = filteredTrips
                .Select(t => EntityUtils.TripToDTrip(t))
                .ToList();
            return dTrips;
        }

        public void Save(DTrip dTrip)
        {
            var trip = EntityUtils.DTripToTrip(dTrip);
            _dbContext.Trips.Add(trip);
            _dbContext.SaveChanges();
        }
    }
}
