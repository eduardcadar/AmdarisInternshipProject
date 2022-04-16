using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.Models;

namespace Infrastructure.DataAccess
{
    public class ReservationDbReader : IReservationReader
    {
        private readonly MicrobuzeContext _dbContext;

        public ReservationDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ReservationDTO> GetByRegularUserId(int regularUserId)
        {
            var reservations = _dbContext.Reservations.Where(r => r.RegularUserId == regularUserId);
            var dReservations = reservations
                .Select(r => EntityUtils.ReservationToReservationDTO(r))
                .ToList();
            return dReservations;
        }

        public IEnumerable<ReservationDTO> GetByTripId(int tripId)
        {
            var reservations = _dbContext.Reservations.Where(r => r.TripId == tripId);
            var dReservations = reservations
                .Select(r => EntityUtils.ReservationToReservationDTO(r))
                .ToList();
            return dReservations;
        }
    }
}
