using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Update
{
    public class UpdateReservation
    {
        public readonly IReservationRepo _reservationRepo;

        public UpdateReservation(IReservationRepo reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }

        public async Task Update(int tripId, int regularUserId, int seats,
            CancellationToken cancellationToken = default)
            => await _reservationRepo.Update(tripId, regularUserId, seats, cancellationToken);
    }
}
