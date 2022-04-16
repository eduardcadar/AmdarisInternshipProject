using System;
using Domain.Domain;
using Domain.Repository;

namespace Application.UseCases.Create
{
    public class CreateTrip
    {
        private readonly ITripRepo _repo;

        public CreateTrip(ITripRepo repo)
        {
            _repo = repo;
        }

        public void Create(DAgencyUser dAgencyUser, string departureLocation, string destination,
            DateTime departureTime, TimeSpan duration, double price, int seats)
        {
            var trip = dAgencyUser.CreateTrip(departureLocation, destination, departureTime, duration, price, seats);
            _repo.Add(trip);
        }
    }
}
