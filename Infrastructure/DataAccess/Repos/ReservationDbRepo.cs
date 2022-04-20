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
        }

        public async Task Delete(DReservation dReservation, CancellationToken cancellationToken = default)
        {
            var reservation = EntityUtils.DReservationToReservation(dReservation);
            _dbContext.Remove(reservation);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Add(DReservation dReservation, CancellationToken cancellationToken = default)
        {
            var reservation = EntityUtils.DReservationToReservation(dReservation);
            await _dbContext.Reservations.AddAsync(reservation, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
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
