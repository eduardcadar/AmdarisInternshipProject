using System.Collections.Generic;
using Application.Domain;

namespace Application.Service
{
    public class Service
    {
        private readonly AgencyUserService agencyUserSrv;
        private readonly RegularUserService regularUserSrv;
        private readonly TripService tripSrv;
        private readonly ReservationService resSrv;
        public Service(AgencyUserService agencyUserSrv, RegularUserService regularUserSrv,
            TripService tripSrv, ReservationService resSrv)
        {
            this.agencyUserSrv = agencyUserSrv;
            this.regularUserSrv = regularUserSrv;
            this.tripSrv = tripSrv;
            this.resSrv = resSrv;
        }
        public AgencyUser GetAgencyUser(int id) => agencyUserSrv.Get(id);
        public RegularUser GetRegularUser(int id) => regularUserSrv.Get(id);
        public List<Trip> GetTripsFiltered(string destination, string departureLocation)
            => tripSrv.GetTripsFiltered(destination, departureLocation);
        public List<Reservation> GetReservationsForUser(User user)
            => resSrv.GetReservationsForUser(user);
        public void SaveReservation(Reservation reservation) => resSrv.Save(reservation);
        public void SaveTrip(Trip trip) => tripSrv.Save(trip);
    }
}
