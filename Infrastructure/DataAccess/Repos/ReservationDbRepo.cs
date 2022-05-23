using Domain.Domain;
using Domain.Repository;
using Infrastructure.Persistence.Entities;
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

        public async Task Delete(int tripId, int regularUserId, CancellationToken cancellationToken = default)
        {
            var reservation = new Reservation()
            {
                TripId = tripId,
                RegularUserId = regularUserId
            };
            _dbContext.Reservations.Attach(reservation);
            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<DReservation> Add(DReservation dReservation, CancellationToken cancellationToken = default)
        {
            var trip = await _dbContext.Trips
                .SingleOrDefaultAsync(t => t.Id.Equals(dReservation.Trip.Id), cancellationToken);
            if (trip == null)
                throw new RepositoryException("Cursa nu exista");

            trip.Agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyId), cancellationToken);
            if (trip.Agency == null)
                throw new RepositoryException("Agentia nu exista");

            var regularUser = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Id.Equals(dReservation.RegularUser.Id), cancellationToken);
            if (regularUser == null)
                throw new RepositoryException("User-ul nu exista");

            if (await _dbContext.Reservations.AnyAsync(r => r.TripId == dReservation.Trip.Id && r.RegularUserId == dReservation.RegularUser.Id))
                throw new RepositoryException("Aveti deja o rezervare la aceasta cursa," +
                    " daca doriti sa mai rezervati locuri, actualizati rezervarea din pagina contului");

            var totalSeatsReserved = _dbContext.Reservations
                .Where(r => r.TripId == dReservation.Trip.Id)
                .Sum(r => r.Seats);
            var seatsLeft = trip.Seats - totalSeatsReserved;
            if (seatsLeft < dReservation.Seats)
            {
                string err = "";
                if (seatsLeft == 0)
                    err = "Nu mai sunt locuri libere la aceasta cursa";
                else
                    err = "Mai sunt doar " + seatsLeft + " locuri libere la aceasta cursa";
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

        public async Task Update(DReservation dReservation, CancellationToken cancellationToken = default)
        {
            var reservation = EntityUtils.DReservationToReservation(dReservation);
            var dbReservation = await _dbContext.Reservations.SingleAsync(
                r => r.RegularUserId.Equals(reservation.RegularUserId) && r.TripId.Equals(reservation.TripId), cancellationToken);
            if (dbReservation == null)
                throw new RepositoryException("There is no reservation with this id");
            dbReservation.Seats = reservation.Seats;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
