using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models;

namespace Application.ReaderInterfaces
{
    public interface IReservationReader
    {
        Task<IEnumerable<ReservationDTO>> GetByRegularUserId(int regularUserId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReservationDTO>> GetByTripId(int tripId, CancellationToken cancellationToken = default);
    }
}
