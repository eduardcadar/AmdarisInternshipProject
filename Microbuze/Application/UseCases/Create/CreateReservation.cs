using Domain.Domain;
using Domain.Repository;

namespace Application.UseCases.Create
{
    public class CreateReservation
    {
        private readonly IReservationRepo _repo;

        public CreateReservation(IReservationRepo repo)
        {
            _repo = repo;
        }

        public void Create(DTrip trip, DRegularUser regularUser, int seats)
        {
            var dReservation = regularUser.CreateReservation(trip, seats);
            _repo.Add(dReservation);
        }
    }
}
