using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models;
using Application.Services.Interfaces;
using Application.UseCases.Create;
using Application.UseCases.Find;
using Domain.Domain;

namespace Application.Services
{
    public class TripsService : ITripsService
    {
        private readonly CreateTrip _createTrip;
        private readonly FindTripsFiltered _findTripsFiltered;
        private readonly FindTripById _findTripById;

        public TripsService(CreateTrip createTrip, FindTripsFiltered findTripsFiltered,
            FindTripById findTripById)
        {
            _createTrip = createTrip;
            _findTripsFiltered = findTripsFiltered;
            _findTripById = findTripById;
        }

        public async Task<DTrip> CreateTrip(DAgencyUser dAgencyUser, string departureLocation, string destination,
            DateTime departureTime, TimeSpan duration, double price, int seats, CancellationToken cancellationToken = default)
            => await _createTrip.Create(dAgencyUser, departureLocation, destination,
                departureTime,duration, price, seats, cancellationToken);

        public async Task<TripDTO> FindTripById(int id, CancellationToken cancellationToken = default)
            => await _findTripById.Find(id, cancellationToken);

        public async Task<IEnumerable<TripDTO>> FindTripsFiltered(string departureLocation, string destination,
            CancellationToken cancellationToken = default)
            => await _findTripsFiltered.Find(departureLocation, destination, cancellationToken);
    }
}
