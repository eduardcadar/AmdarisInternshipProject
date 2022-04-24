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
            var reservationDTO = EntityUtils.ReservationToReservationDTO(reservation);
            return reservationDTO;
        }

        public async Task<IEnumerable<ReservationDTO>> GetByRegularUserId(int regularUserId, CancellationToken cancellationToken = default)
        {
            var reservations = _dbContext.Reservations.Where(r => r.RegularUserId == regularUserId);
            var dReservations = await reservations
                .Select(r => EntityUtils.ReservationToReservationDTO(r))
                .ToListAsync(cancellationToken);
            return dReservations;
        }

        public async Task<IEnumerable<ReservationDTO>> GetByTripId(int tripId, CancellationToken cancellationToken = default)
        {
            var reservations = _dbContext.Reservations.Where(r => r.TripId == tripId);
            var dReservations = await reservations
                .Select(r => EntityUtils.ReservationToReservationDTO(r))
                .ToListAsync(cancellationToken);
            return dReservations;
        }
    }
}
