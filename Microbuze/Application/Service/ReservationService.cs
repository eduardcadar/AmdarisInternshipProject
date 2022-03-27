using System.Collections.Generic;
using Application.Domain;
using Application.Repository;

namespace Application.Service
{
    public class ReservationService
    {
        private readonly IReservationRepo repo;
        public ReservationService(IReservationRepo repo) { this.repo = repo; }
        public List<Reservation> GetReservationsForUser(User user)
            => repo.GetReservationsForUser(user);
        public void Save(Reservation reservation) => repo.Save(reservation);
    }
}
