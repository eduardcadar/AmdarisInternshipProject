using System.Collections.Generic;
using System.Linq;
using Application.ReaderInterfaces;
using Application.Models;
using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Readers
{
    public class TripDbReader : ITripReader
    {
        private readonly MicrobuzeContext _dbContext;

        public TripDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TripDTO> GetById(int id, CancellationToken cancellationToken = default)
        {
            var trip = await _dbContext.Trips.SingleAsync(t => t.Id.Equals(id), cancellationToken);
            if (trip == null)
                throw new RepositoryException("There is no trip with this id");
            var dTrip = EntityUtils.TripToTripDTO(trip);
            return dTrip;
        }

        public async Task<IEnumerable<TripDTO>> GetFiltered(string departureLocation = "", string destination = "", CancellationToken cancellationToken = default)
        {
            var filteredTripEntities = _dbContext.Trips
                .Where(t => t.DepartureLocation.Contains(departureLocation) && t.Destination.Contains(destination));
            var tripDtos = await filteredTripEntities
                .Select(t => EntityUtils.TripToTripDTO(t))
                .ToListAsync(cancellationToken);
            return tripDtos;
        }
    }
}
