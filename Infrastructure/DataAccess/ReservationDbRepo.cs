using System.Collections.Generic;
using System.Linq;
using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    public class ReservationDbRepo : IReservationRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public ReservationDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(DReservation dReservation)
        {
            var reservation = EntityUtils.DReservationToReservation(dReservation);
            _dbContext.Remove(reservation);
            _dbContext.SaveChanges();
        }

        public IEnumerable<DReservation> GetByRegularUserId(int regularUserId)
        {
            var reservations = _dbContext.Reservations.Where(r => r.RegularUserId == regularUserId);
            var dReservations = reservations
                .Select(r => EntityUtils.ReservationToDReservation(r))
                .ToList();
            return dReservations;
        }

        public IEnumerable<DReservation> GetByTripId(int tripId)
        {
            var reservations = _dbContext.Reservations.Where(r => r.TripId == tripId);
            var dReservations = reservations
                .Select(r => EntityUtils.ReservationToDReservation(r))
                .ToList();
            return dReservations;
        }

        public void Save(DReservation dReservation)
        {
            var reservation = EntityUtils.DReservationToReservation(dReservation);
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }

        public void Update(DReservation dReservation)
        {
            var reservation = EntityUtils.DReservationToReservation(dReservation);
            var dbReservation = _dbContext.Reservations.Find(reservation.RegularUserId, reservation.TripId);
            if (dbReservation == null)
                throw new RepositoryException("There is no reservation with this id");
            dbReservation.Seats = reservation.Seats;
            _dbContext.SaveChanges();
        }
    }
}
