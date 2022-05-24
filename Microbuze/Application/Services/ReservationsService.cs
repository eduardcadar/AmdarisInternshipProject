using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Domain;
using Application.UseCases.Create;
using Application.UseCases.Find;
using Application.UseCases.Delete;
using Application.UseCases.Update;

namespace Application.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly CreateReservation _createReservation;
        private readonly FindReservationsByRegularUserId _findReservationsByRegularUserId;
        private readonly FindReservationsByTripId _findReservationsByTripId;
        private readonly FindReservationById _findReservationsById;
        private readonly DeleteReservation _deleteReservation;
        private readonly UpdateReservation _updateReservation;

        public ReservationsService(
            CreateReservation createReservation,
            FindReservationsByRegularUserId findReservationsByRegularUserId,
            FindReservationsByTripId findReservationsByTripId,
            FindReservationById findReservationsById,
            DeleteReservation deleteReservation,
            UpdateReservation updateReservation)
        {
            _createReservation = createReservation;
            _findReservationsByRegularUserId = findReservationsByRegularUserId;
            _findReservationsByTripId = findReservationsByTripId;
            _findReservationsById = findReservationsById;
            _deleteReservation = deleteReservation;
            _updateReservation = updateReservation;
        }

        public async Task<DReservation> CreateReservation(int tripId, int regularUserId, int seats, CancellationToken cancellationToken = default)
            => await _createReservation.Create(tripId, regularUserId, seats, cancellationToken);

        public Task<ReservationDTO> FindReservationById(int userId, int tripId, CancellationToken cancellationToken = default)
            => _findReservationsById.Find(userId, tripId, cancellationToken);

        public async Task<IEnumerable<ReservationDTO>> FindReservationsByRegularUserId(int id, CancellationToken cancellationToken = default)
            => await _findReservationsByRegularUserId.Find(id, cancellationToken);

        public async Task<IEnumerable<ReservationDTO>> FindReservationsByTripId(int id, CancellationToken cancellationToken = default)
            => await _findReservationsByTripId.Find(id, cancellationToken);

        public async Task DeleteReservation(int tripId, int regularUserId, CancellationToken cancellationToken = default)
            => await _deleteReservation.Delete(tripId, regularUserId, cancellationToken);

        public Task UpdateReservation(int tripId, int regularUserId, int seats,
            CancellationToken cancellationToken = default)
            => _updateReservation.Update(tripId, regularUserId, seats, cancellationToken);
    }
}
