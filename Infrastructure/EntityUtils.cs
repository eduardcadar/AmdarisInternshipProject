using System;
using Domain.Domain;
using Infrastructure.Persistence.Entities;

namespace Infrastructure
{
    public static class EntityUtils
    {
        public static DAgencyUser AgencyUserToDAgencyUser(AgencyUser agencyUser)
        {
            var dAgency = new DAgency(agencyUser.Id, agencyUser.Agency.AgencyName, agencyUser.PhoneNumber);
            var dAgencyUser = new DAgencyUser(agencyUser.Id, agencyUser.Username, agencyUser.Password, agencyUser.PhoneNumber, dAgency);
            return dAgencyUser;
        }

        public static Agency DAgencytoAgency(DAgency dAgency)
        {
            var agency = new Agency { Id = dAgency.Id, AgencyName = dAgency.AgencyName, PhoneNumber = dAgency.PhoneNumber };
            return agency;
        }

        public static DAgency AgencyToDAgency(Agency agency)
        {
            var dAgency = new DAgency(agency.Id, agency.AgencyName, agency.PhoneNumber);
            return dAgency;
        }

        public static DReservation ReservationToDReservation(Reservation r)
        {
            throw new NotImplementedException();
        }

        public static DTrip TripToDTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public static Trip DTripToTrip(DTrip dTrip)
        {
            var trip = new Trip
            {
                Id = dTrip.Id,
                AgencyId = dTrip.Agency.Id,
                DepartureLocation = dTrip.DepartureLocation,
                Destination = dTrip.Destination,
                DepartureTime = dTrip.DepartureTime,
                Duration = dTrip.Duration,
                Price = dTrip.Price,
                Seats = dTrip.Seats
            };
            return trip;
        }

        public static DRegularUser RegularUserToDRegularUser(RegularUser regularUser)
        {
            var dRegularUser = new DRegularUser(regularUser.Id, regularUser.Username, regularUser.Password, regularUser.PhoneNumber, regularUser.FirstName, regularUser.LastName);
            return dRegularUser;
        }

        public static Reservation DReservationToReservation(DReservation dReservation)
        {
            var reservation = new Reservation { RegularUserId = dReservation.RegularUser.Id, TripId = dReservation.Trip.Id, Seats = dReservation.Seats };
            return reservation;
        }

        public static AgencyUser DAgencyUserToAgencyUser(DAgencyUser dAgencyUser)
        {
            var agency = DAgencytoAgency(dAgencyUser.Agency);
            var agencyUser = new AgencyUser { Id = dAgencyUser.Id, Agency = agency, AgencyId = agency.Id,
                Password = dAgencyUser.Password, Username = dAgencyUser.Username, PhoneNumber = dAgencyUser.PhoneNumber };
            return agencyUser;
        }
    }
}
