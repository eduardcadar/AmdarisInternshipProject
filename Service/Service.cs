using System;
using System.Collections.Generic;
using Domain.Domain;

namespace Service
{
    public class Service
    {
        private AgencyService agencySrv;
        private TripService tripSrv;
        private ReservationService resSrv;
        public Service(AgencyService agencySrv, TripService tripSrv, ReservationService resSrv)
        {
            this.agencySrv = agencySrv;
            this.tripSrv = tripSrv;
            this.resSrv = resSrv;
        }
        public void SaveAgency(string agencyName) => this.agencySrv.Save(agencyName);
        public void SaveTrip(Agency ag, string depLoc, string dest, DateTime depTime,
            TimeSpan duration, float price, int seats) => this.tripSrv.Save(
                ag, depLoc, dest, depTime, duration, price, seats);
        public void SaveReservation(Trip trip, User user, int seatsNumber)
            => this.resSrv.Save(trip, user, seatsNumber);
        public ICollection<Agency> GetAllAgencies() => this.agencySrv.GetAll();
        public ICollection<Trip> GetAllTrips => this.tripSrv.GetAll();
        public ICollection<Reservation> GetAllReservations() => this.resSrv.GetAll();
    }
}
