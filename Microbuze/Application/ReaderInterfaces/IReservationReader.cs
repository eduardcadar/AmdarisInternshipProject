using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.ReaderInterfaces
{
    public interface IReservationReader
    {
        Task<IEnumerable<ReservationDTO>> GetByRegularUserId(int regularUserId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReservationDTO>> GetByTripId(int tripId, CancellationToken cancellationToken = default);
        Task<ReservationDTO> GetById(int userId, int tripId, CancellationToken cancellationToken = default);
    }
}
