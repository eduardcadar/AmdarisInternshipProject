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

        public async Task<DReservation> Create(DTrip trip, DRegularUser regularUser, int seats, CancellationToken cancellationToken = default)
        {
            var dReservation = regularUser.CreateReservation(trip, seats);
            return await _reservationRepo.Add(dReservation, cancellationToken);
        }
    }
}
