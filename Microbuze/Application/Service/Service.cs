using System.Collections.Generic;
using Application.Domain;

namespace Application.Service
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
        public AgencyUser GetAgencyUser(int id) => _agencyUserSrv.Get(id);
        public RegularUser GetRegularUser(int id) => _regularUserSrv.Get(id);
        public List<Trip> GetTripsFiltered(string destination, string departureLocation)
            => _tripSrv.GetTripsFiltered(destination, departureLocation);
        public List<Reservation> GetReservationsForUser(User user)
            => _resSrv.GetReservationsForUser(user);
        public void SaveReservation(Reservation reservation) => _resSrv.Save(reservation);
        public void SaveTrip(Trip trip) => _tripSrv.Save(trip);
        public void ExportAgencyToCsv(Agency agency) => _agencySrv.ExportToCsv(agency);
        public void ExportAgencyToNaturalLanguage(Agency agency) => _agencySrv.ExportToNaturalLanguage(agency);
        public void ExportTripToCsv(Trip trip) => _tripSrv.ExportToCsv(trip);
        public void ExportTripToNaturalLanguage(Trip trip) => _tripSrv.ExportToNaturalLanguage(trip);
    }
}
