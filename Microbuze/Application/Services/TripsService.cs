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

        public TripsService(CreateTrip createTrip, FindTripsFiltered findTripsFiltered)
        {
            _createTrip = createTrip;
            _findTripsFiltered = findTripsFiltered;
        }

        public async Task CreateTrip(DAgencyUser dAgencyUser, string departureLocation, string destination,
            DateTime departureTime, TimeSpan duration, double price, int seats, CancellationToken cancellationToken = default)
            => await _createTrip.Create(dAgencyUser, departureLocation, destination,
                departureTime,duration, price, seats, cancellationToken);

        public async Task<IEnumerable<TripDTO>> FindTripsFiltered(string departureLocation, string destination,
            CancellationToken cancellationToken = default)
            => await _findTripsFiltered.Find(departureLocation, destination, cancellationToken);
    }
}
