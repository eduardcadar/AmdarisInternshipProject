using Application.DTOs;
using Domain.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IReservationsService
    {
        Task<DReservation> CreateReservation(int tripId, int regularUserId, int seats, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReservationDTO>> FindReservationsByRegularUserId(int id,
            CancellationToken cancellationToken = default);
        Task<IEnumerable<ReservationDTO>> FindReservationsByTripId(int id,
            CancellationToken cancellationToken = default);
        Task<ReservationDTO> FindReservationById(int userId, int tripId, CancellationToken cancellationToken = default);
        Task DeleteReservation(int tripId, int regularUserId, CancellationToken cancellationToken = default);
    }
}
