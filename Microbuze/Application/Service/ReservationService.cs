using System.Collections.Generic;
using Domain.Domain;
using Domain.Repository;

namespace Domain.Service
{
    public class ReservationService
    {
        private readonly IReservationRepo _repo;
        public ReservationService(IReservationRepo repo) { _repo = repo; }
        public IEnumerable<DReservation> GetByRegularUser(DRegularUser user)
            => _repo.GetByRegularUserId(user.Id);
        public void Save(DReservation reservation) => _repo.Save(reservation);
    }
}
