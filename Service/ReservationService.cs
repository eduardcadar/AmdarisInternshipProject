using System;
using System.Collections.Generic;
using Domain.Domain;
using Domain.Repository;

namespace Service
{
    public class ReservationService
    {
        private IReservationRepo repo;
        public ReservationService(IReservationRepo repo) { this.repo = repo; }
        public void Save(Trip trip, User user, int seatsNumber)
            => this.repo.Save(new Reservation(trip, user, seatsNumber));
        public Reservation GetById(Trip trip, User user)
            => this.repo.GetById(new Tuple<Trip, User>(trip, user));
        public ICollection<Reservation> GetAll() => this.repo.GetAll();
    }
}
