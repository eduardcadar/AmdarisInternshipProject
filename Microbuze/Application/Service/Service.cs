using System;
using System.Collections.Generic;
using Domain.Domain;

namespace Domain.Service
{
    public class Service
    {
        private readonly AgencyService _agencySrv;
        private readonly AgencyUserService _agencyUserSrv;
        private readonly RegularUserService _regularUserSrv;
        private readonly TripService _tripSrv;
        private readonly ReservationService _resSrv;

        public Service(AgencyService agencySrv, AgencyUserService agencyUserSrv, RegularUserService regularUserSrv,
            TripService tripSrv, ReservationService resSrv)
        {
            _agencySrv = agencySrv;
            _agencyUserSrv = agencyUserSrv;
            _regularUserSrv = regularUserSrv;
            _tripSrv = tripSrv;
            _resSrv = resSrv;
        }

        public DAgencyUser GetAgencyUser(int id) => _agencyUserSrv.Get(id);

        public DRegularUser GetRegularUser(int id) => _regularUserSrv.Get(id);

        public IEnumerable<DTrip> GetTripsFiltered(string destination, string departureLocation)
            => _tripSrv.GetFiltered(destination, departureLocation);

        public IEnumerable<DReservation> GetReservationsForUser(DRegularUser user)
            => _resSrv.GetByRegularUser(user);

        public void SaveReservation(DReservation reservation) => _resSrv.Save(reservation);

        public void ExportAgencyToCsv(DAgency agency) => _agencySrv.ExportToCsv(agency);

        public void ExportAgencyToNaturalLanguage(DAgency agency) => _agencySrv.ExportToNaturalLanguage(agency);

        public void ExportTripToCsv(DTrip trip) => _tripSrv.ExportToCsv(trip);

        public void ExportTripToNaturalLanguage(DTrip trip) => _tripSrv.ExportToNaturalLanguage(trip);

        public void CreateTrip(DAgencyUser user, string departureLocation, string destination, DateTime depTime,
            TimeSpan duration, double price, int seats)
        {
            var tr = user.CreateTrip(departureLocation, destination, depTime, duration, price, seats);
            //_tripSrv.Save(tr);
        }

        //public TripDTO ReadTripById(int id)
        //{
        //    var tr = _tripSrv.GetById(id);
        //    return new TripDTO(tr);
        //}
    }
}
