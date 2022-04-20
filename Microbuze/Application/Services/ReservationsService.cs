using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models;
using Application.Services.Interfaces;
using Domain.Domain;
using Application.UseCases.Create;
using Application.UseCases.Find;

namespace Application.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly CreateReservation _createReservation;
        private readonly FindReservationsByRegularUserId _findReservationsByRegularUserId;
        private readonly FindReservationsByTripId _findReservationsByTripId;
        private readonly FindReservationById _findReservationsById;

        public ReservationsService(CreateReservation createReservation, FindReservationsByRegularUserId findReservationsByRegularUserId, FindReservationsByTripId findReservationsByTripId, FindReservationById findReservationsById)
        {
            _createReservation = createReservation;
            _findReservationsByRegularUserId = findReservationsByRegularUserId;
            _findReservationsByTripId = findReservationsByTripId;
            _findReservationsById = findReservationsById;
        }

        public async Task<DReservation> CreateReservation(DTrip trip, DRegularUser regularUser, int seats, CancellationToken cancellationToken = default)
            => await _createReservation.Create(trip, regularUser, seats, cancellationToken);

        public Task<ReservationDTO> FindReservationById(int userId, int tripId, CancellationToken cancellationToken = default)
            => _findReservationsById.Find(userId, tripId, cancellationToken);

        public async Task<IEnumerable<ReservationDTO>> FindReservationsByRegularUserId(int id, CancellationToken cancellationToken = default)
            => await _findReservationsByRegularUserId.Find(id, cancellationToken);

        public async Task<IEnumerable<ReservationDTO>> FindReservationsByTripId(int id, CancellationToken cancellationToken = default)
            => await _findReservationsByTripId.Find(id, cancellationToken);
    }
}
