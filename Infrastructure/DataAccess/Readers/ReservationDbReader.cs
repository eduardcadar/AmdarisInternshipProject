using System.Collections.Generic;
using System.Linq;
using Application.ReaderInterfaces;
using Application.DTOs;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Domain.Repository;

namespace Infrastructure.DataAccess.Readers
{
    public class ReservationDbReader : IReservationReader
    {
        private readonly MicrobuzeContext _dbContext;

        public ReservationDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<ReservationDTO> GetById(int userId, int tripId, CancellationToken cancellationToken = default)
        {
            var reservation = await _dbContext.Reservations.SingleOrDefaultAsync(
                r => r.RegularUserId == userId && r.TripId == tripId, cancellationToken);
            if (reservation == null)
                return null;

            var trip = await _dbContext.Trips
                .SingleOrDefaultAsync(t => t.Id.Equals(tripId), cancellationToken);
            trip.Agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyId), cancellationToken);
            reservation.Trip = trip;
            var regularUser = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Id.Equals(userId), cancellationToken);
            reservation.RegularUser = regularUser;

            var reservationDTO = EntityUtils.ReservationToReservationDTO(reservation);
            return reservationDTO;
        }

        public async Task<IEnumerable<ReservationDTO>> GetByRegularUserId(int regularUserId, CancellationToken cancellationToken = default)
        {
            var reservations = await _dbContext.Reservations
                .Where(r => r.RegularUserId == regularUserId).ToListAsync(cancellationToken: cancellationToken);

            foreach (var reservation in reservations)
            {
                var trip = await _dbContext.Trips
                .SingleOrDefaultAsync(t => t.Id.Equals(reservation.TripId), cancellationToken);
                trip.Agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyId), cancellationToken);
                reservation.Trip = trip;
                var regularUser = await _dbContext.RegularUsers
                    .SingleOrDefaultAsync(r => r.Id.Equals(reservation.RegularUserId), cancellationToken);
                reservation.RegularUser = regularUser;
            }

            var reservationDTOs = reservations
                .Select(r => EntityUtils.ReservationToReservationDTO(r));

            return reservationDTOs;
        }

        public async Task<IEnumerable<ReservationDTO>> GetByTripId(int tripId, CancellationToken cancellationToken = default)
        {
            var reservations = await _dbContext.Reservations.Where(r => r.TripId == tripId).ToListAsync(cancellationToken);

            foreach (var reservation in reservations)
            {
                var trip = await _dbContext.Trips
                .SingleOrDefaultAsync(t => t.Id.Equals(reservation.TripId), cancellationToken);
                trip.Agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyId), cancellationToken);
                reservation.Trip = trip;
                var regularUser = await _dbContext.RegularUsers
                    .SingleOrDefaultAsync(r => r.Id.Equals(reservation.RegularUserId), cancellationToken);
                reservation.RegularUser = regularUser;
            }

            var reservationDTOs = reservations
                .Select(r => EntityUtils.ReservationToReservationDTO(r));

            return reservationDTOs;
        }
    }
}
