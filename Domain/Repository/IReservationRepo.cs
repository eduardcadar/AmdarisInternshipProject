using System.Collections.Generic;
using Domain.Domain;

namespace Domain.Repository
{
    public interface IReservationRepo
    {
        void Add(DReservation dReservation);
        void Delete(DReservation dReservation);
        void Update(DReservation dReservation);
    }
}
