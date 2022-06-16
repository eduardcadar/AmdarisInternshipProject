using Domain.Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repos
{
    public class ReservationDbRepo : IReservationRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public ReservationDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<DReservation> Add(DReservation dReservation, CancellationToken cancellationToken = default)
        {
            var trip = await _dbContext.Trips
                .SingleOrDefaultAsync(t => t.Id.Equals(dReservation.Trip.Id), cancellationToken);
            if (trip == null)
                throw new RepositoryException("The trip doesn't exist");

            trip.AgencyUser = await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyUserId), cancellationToken);
            if (trip.AgencyUser == null)
                throw new RepositoryException("The agency doesn't exist");

            var regularUser = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Id.Equals(dReservation.RegularUser.Id), cancellationToken);
            if (regularUser == null)
                throw new RepositoryException("The user doesn't exist");

            if (await _dbContext.Reservations
                .AnyAsync(r => r.TripId == dReservation.Trip.Id && r.RegularUserId == dReservation.RegularUser.Id, cancellationToken))
                throw new RepositoryException("You already made a reservation for this trip," +
                    " if you want to reserve more seats update the reservation");

            var totalSeatsReserved = _dbContext.Reservations
                .Where(r => r.TripId == dReservation.Trip.Id)
                .Sum(r => r.Seats);
            var seatsLeft = trip.Seats - totalSeatsReserved;
            if (seatsLeft < dReservation.Seats)
            {
                string err = "";
                if (seatsLeft == 0)
                    err = "No seats left for this trip";
                else
                    err = "Only " + seatsLeft + " seats left for this trip";
                throw new RepositoryException(err);
            }

            var reservation = EntityUtils.DReservationToReservation(dReservation);
            reservation.Trip = null;
            reservation.RegularUser = null;

            await _dbContext.Reservations.AddAsync(reservation, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            dReservation.Trip = EntityUtils.TripToDTrip(trip);
            dReservation.RegularUser = EntityUtils.RegularUserToDRegularUser(regularUser);
            return dReservation;
        }

        public async Task Delete(int tripId, string regularUserId, CancellationToken cancellationToken = default)
        {
            var reservation = await _dbContext.Reservations
                .SingleOrDefaultAsync(r => r.TripId.Equals(tripId) && r.RegularUserId.Equals(regularUserId), cancellationToken);
            if (reservation == null)
                throw new RepositoryException("The reservation doesn't exist");
            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(int tripId, string regularUserId, int seats, CancellationToken cancellationToken = default)
        {
            var trip = await _dbContext.Trips
                .SingleOrDefaultAsync(t => t.Id.Equals(tripId), cancellationToken);
            if (trip == null)
                throw new RepositoryException("The trip doesn't exist");

            if (seats <= 0)
                throw new RepositoryException("Write the number of seats");
            var dbReservation = await _dbContext.Reservations.SingleOrDefaultAsync(
                r => r.RegularUserId.Equals(regularUserId) && r.TripId == tripId, cancellationToken);
            if (dbReservation == null)
                throw new RepositoryException("The user has no reservation to this trip");

            var totalSeatsReserved = _dbContext.Reservations
                .Where(r => r.TripId == tripId)
                .Sum(r => r.Seats);
            int differenceOfSeats = seats - dbReservation.Seats;
            var seatsLeft = trip.Seats - totalSeatsReserved;
            if (seatsLeft < differenceOfSeats)
            {
                string err = "";
                if (seatsLeft == 0)
                    err = "No seats left for this trip";
                else
                    err = "Only " + seatsLeft + " seats left for this trip";
                throw new RepositoryException(err);
            }

            dbReservation.Seats = seats;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
