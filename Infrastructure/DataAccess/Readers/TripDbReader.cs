using System.Collections.Generic;
using System.Linq;
using Application.ReaderInterfaces;
using Application.DTOs;
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
            _dbContext.Database.EnsureCreated();
        }

        public async Task<TripDTO> GetById(int id, CancellationToken cancellationToken = default)
        {
            var trip = await _dbContext.Trips.SingleOrDefaultAsync(t => t.Id.Equals(id), cancellationToken);
            if (trip == null)
                return null;
            trip.Agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyId), cancellationToken);
            var dTrip = EntityUtils.TripToTripDTO(trip);
            return dTrip;
        }

        public async Task<IEnumerable<TripDTO>> GetFiltered(string departureLocation = "", string destination = "", CancellationToken cancellationToken = default)
        {
            var filteredTripEntities = await _dbContext.Trips
                .Where(t => t.DepartureLocation.Contains(departureLocation) && t.Destination.Contains(destination))
                .ToListAsync(cancellationToken);

            foreach (var trip in filteredTripEntities)
                trip.Agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyId), cancellationToken);

            var tripDtos = filteredTripEntities
                .Select(t => EntityUtils.TripToTripDTO(t));
            return tripDtos;
        }
    }
}
