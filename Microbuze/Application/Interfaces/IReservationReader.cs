using System.Collections.Generic;
using Application.Models;

namespace Application.Interfaces
{
    public interface IReservationReader
    {
        IEnumerable<ReservationDTO> GetByRegularUserId(int regularUserId);
        IEnumerable<ReservationDTO> GetByTripId(int tripId);
    }
}
