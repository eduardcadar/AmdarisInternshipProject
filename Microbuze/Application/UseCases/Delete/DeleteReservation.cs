using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Delete
{
    public class DeleteReservation
    {
        public readonly IReservationRepo _reservationRepo;

        public DeleteReservation(IReservationRepo reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }

        public async Task Delete(int tripId, string regularUserId, CancellationToken cancellationToken = default)
            => await _reservationRepo.Delete(tripId, regularUserId, cancellationToken);
    }
}
