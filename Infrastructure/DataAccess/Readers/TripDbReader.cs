using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.Models;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    public class TripDbReader : ITripReader
    {
        private readonly MicrobuzeContext _dbContext;

        public TripDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TripDTO GetById(int id)
        {
            var trip = _dbContext.Trips.Find(id);
            if (trip == null)
                throw new RepositoryException("There is no trip with this id");
            var dTrip = EntityUtils.TripToTripDTO(trip);
            return dTrip;
        }

        public IEnumerable<TripDTO> GetFiltered(string departureLocation = "", string destination = "")
        {
            var filteredTripEntities = _dbContext.Trips
                .Where(t => t.DepartureLocation.Contains(departureLocation) && t.Destination.Contains(destination));
            var tripDtos = filteredTripEntities
                .Select(t => EntityUtils.TripToTripDTO(t))
                .ToList();
            return tripDtos;
        }
    }
}
