using System;
using System.Collections.Generic;
using Domain.Domain;
using Domain.Repository;

namespace Service
{
    public class TripService
    {
        private ITripRepo repo;
        public TripService(ITripRepo repo) { this.repo = repo; }
        public void Save(Agency ag, string depLoc, string dest, DateTime depTime,
            TimeSpan duration, float price, int seats) => this.repo.Save(
                new Trip(ag, depLoc, dest, depTime, duration, price, seats));
        public Trip GetById(int id) => this.repo.GetById(id);
        public ICollection<Trip> GetAll() => this.repo.GetAll();
    }
}
