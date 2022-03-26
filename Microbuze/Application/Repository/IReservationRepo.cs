using System.Collections.Generic;
using Domain.Domain;

namespace Domain.Repository
{
    public interface IReservationRepo
    {
        public void Save(Reservation reservation);
        public void Delete(Reservation reservation);
        public void Update(Reservation reservation);
        public List<Reservation> GetReservationsForUser(User user);
    }
}
