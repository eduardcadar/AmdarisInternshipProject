using System.Collections.Generic;
using System.Linq;
using Application.ReaderInterfaces;
using Application.DTOs;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

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
            trip.AgencyUser = await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyUserId), cancellationToken);
            var dTrip = EntityUtils.TripToTripDTO(trip);
            return dTrip;
        }

        public async Task<IEnumerable<TripDTO>> GetByAgency(string agency, CancellationToken cancellationToken = default)
        {
            var trips = await _dbContext.Trips
                .Where(t => t.AgencyUser.Agency.Equals(agency))
                .Select(t => EntityUtils.TripToTripDTO(t))
                .OrderBy(t => t.DepartureTime)
                .ToListAsync(cancellationToken);
            return trips;
        }

        public async Task<IEnumerable<TripDTO>> GetFiltered(string agency = "", string departureLocation = "", string destination = "", DateTime? date = null, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Trips
                .Where(t =>
                    t.DepartureLocation.Contains(departureLocation) &&
                    t.Destination.Contains(destination) &&
                    t.DepartureTime > DateTime.Now &&
                    t.AgencyUser.Agency.Contains(agency));
            if (date != null)
                query = query.Where(t => t.DepartureTime.Date == date.Value.Date);

            var filteredTripEntities = await query
                .OrderBy(t => t.DepartureTime)
                .ToListAsync(cancellationToken);

            foreach (var trip in filteredTripEntities)
            {
                trip.AgencyUser = await _dbContext.AgencyUsers
                    .SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyUserId), cancellationToken);
                trip.Seats -= _dbContext.Reservations.Where(r => r.TripId == trip.Id).Sum(r => r.Seats);
            }
            var tripDtos = filteredTripEntities
                .Select(t => EntityUtils.TripToTripDTO(t));
            return tripDtos;
        }
    }
}
