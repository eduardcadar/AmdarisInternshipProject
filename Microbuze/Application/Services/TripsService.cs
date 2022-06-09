using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using Application.UseCases.Create;
using Application.UseCases.Delete;
using Application.UseCases.Find;
using Domain.Domain;

namespace Application.Services
{
    public class TripsService : ITripsService
    {
        private readonly CreateTrip _createTrip;
        private readonly FindTripsFiltered _findTripsFiltered;
        private readonly FindTripById _findTripById;
        private readonly DeleteTrip _deleteTrip;

        public TripsService(CreateTrip createTrip, FindTripsFiltered findTripsFiltered,
            FindTripById findTripById, DeleteTrip deleteTrip)
        {
            _createTrip = createTrip;
            _findTripsFiltered = findTripsFiltered;
            _findTripById = findTripById;
            _deleteTrip = deleteTrip;
        }

        public async Task<DTrip> CreateTrip(string agencyUserId, string departureLocation, string destination,
            DateTime departureTime, TimeSpan duration, double price, int seats, CancellationToken cancellationToken = default)
            => await _createTrip.Create(agencyUserId, departureLocation, destination,
                departureTime,duration, price, seats, cancellationToken);

        public Task DeleteTrip(int tripId, CancellationToken cancellationToken = default)
            => _deleteTrip.Delete(tripId, cancellationToken);

        public async Task<TripDTO> FindTripById(int id, CancellationToken cancellationToken = default)
            => await _findTripById.Find(id, cancellationToken);

        public async Task<IEnumerable<TripDTO>> FindTripsFiltered(string agency, string departureLocation, string destination,
            DateTime? date = null, CancellationToken cancellationToken = default)
            => await _findTripsFiltered.Find(agency, departureLocation, destination, date, cancellationToken);
    }
}
