using Domain.Domain;
using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Create
{
    public class CreateReservation
    {
        private readonly IReservationRepo _reservationRepo;

        public CreateReservation(IReservationRepo repo)
        {
            _reservationRepo = repo;
        }

        public async Task<DReservation> Create(int tripId, int regularUserId, int seats, CancellationToken cancellationToken = default)
        {
            var dReservation = new DReservation(new DTrip { Id = tripId }, new DRegularUser { Id = regularUserId }, seats);
            return await _reservationRepo.Add(dReservation, cancellationToken);
        }
    }
}
