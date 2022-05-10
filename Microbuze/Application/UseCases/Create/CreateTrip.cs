﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Repository;

namespace Application.UseCases.Create
{
    public class CreateTrip
    {
        private readonly ITripRepo _tripRepo;

        public CreateTrip(ITripRepo repo)
        {
            _tripRepo = repo;
        }

        public async Task<DTrip> Create(int agencyId, string departureLocation, string destination,
            DateTime departureTime, TimeSpan duration, double price, int seats, CancellationToken cancellationToken = default)
        {
            var trip = new DTrip(new DAgency { Id = agencyId }, departureLocation, destination, departureTime, duration, price, seats);
            return await _tripRepo.Add(trip, cancellationToken);
        }
    }
}
