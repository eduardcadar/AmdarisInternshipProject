using System.Collections.Generic;
using Domain.Domain;

namespace Domain.Repository
{
    public interface IReservationRepo
    {
        public void Save(DReservation dReservation);
        public void Delete(DReservation dReservation);
        public void Update(DReservation dReservation);
        public IEnumerable<DReservation> GetByRegularUserId(int regularUserId);
        public IEnumerable<DReservation> GetByTripId(int tripId);
    }
}
