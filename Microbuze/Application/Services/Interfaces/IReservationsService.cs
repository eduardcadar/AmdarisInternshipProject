using Application.DTOs;
using Domain.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IReservationsService
    {
        Task<DReservation> CreateReservation(int tripId, string regularUserId, int seats, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReservationDTO>> FindReservationsByRegularUserId(string regularUserId,
            CancellationToken cancellationToken = default);
        Task<IEnumerable<ReservationDTO>> FindReservationsByTripId(int tripId,
            CancellationToken cancellationToken = default);
        Task<ReservationDTO> FindReservationById(string userId, int tripId, CancellationToken cancellationToken = default);
        Task DeleteReservation(int tripId, string regularUserId, CancellationToken cancellationToken = default);
        Task UpdateReservation(int tripId, string regularUserId, int seats, CancellationToken cancellationToken = default);
    }
}
