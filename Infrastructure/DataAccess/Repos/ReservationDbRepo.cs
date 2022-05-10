using Domain.Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
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

        public async Task Delete(DReservation dReservation, CancellationToken cancellationToken = default)
        {
            var reservation = EntityUtils.DReservationToReservation(dReservation);
            _dbContext.Remove(reservation);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<DReservation> Add(DReservation dReservation, CancellationToken cancellationToken = default)
        {
            var reservation = EntityUtils.DReservationToReservation(dReservation);
            reservation.Trip = null;
            reservation.RegularUser = null;
            await _dbContext.Reservations.AddAsync(reservation, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var trip = await _dbContext.Trips
                .SingleOrDefaultAsync(t => t.Id.Equals(dReservation.Trip.Id), cancellationToken);
            trip.Agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyId), cancellationToken);
            dReservation.Trip = EntityUtils.TripToDTrip(trip);
            var regularUser = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Id.Equals(dReservation.RegularUser.Id), cancellationToken);
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
