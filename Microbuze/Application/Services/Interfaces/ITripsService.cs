using Application.DTOs;
using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITripsService
    {
        Task<DTrip> CreateTrip(string agencyUserId, string departureLocation, string destination,
            DateTime departureTime, TimeSpan duration, double price, int seats, CancellationToken cancellationToken = default);
        Task<IEnumerable<TripDTO>> FindTripsFiltered(string agency, string departureLocation, string destination,
            DateTime? date = null, CancellationToken cancellationToken = default);
        Task<TripDTO> FindTripById(int id, CancellationToken cancellationToken = default);
    }
}
