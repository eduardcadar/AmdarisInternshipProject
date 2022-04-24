using System;
using Application.DTOs;
using Domain.Domain;
using Infrastructure.Persistence.Entities;

namespace Infrastructure
{
    public static class EntityUtils
    {
        public static DAgencyUser AgencyUserToDAgencyUser(AgencyUser agencyUser)
        {
            var dAgency = new DAgency(agencyUser.Agency.AgencyName, agencyUser.PhoneNumber)
            {
                Id = agencyUser.Id,
            };
            var dAgencyUser = new DAgencyUser(agencyUser.Username, agencyUser.Password, agencyUser.PhoneNumber, dAgency)
            {
                Id = agencyUser.Id,
            };
            return dAgencyUser;
        }

        public static RegularUser DRegularUserToRegularUser(DRegularUser dRegularUser)
        {
            var regularUser = new RegularUser
            {
                Id = dRegularUser.Id,
                Username = dRegularUser.Username,
                Password = dRegularUser.Password,
                PhoneNumber = dRegularUser.PhoneNumber,
                FirstName = dRegularUser.FirstName,
                LastName = dRegularUser.LastName
            };
            return regularUser;
        }

        public static AgencyUserDTO AgencyUserToAgencyUserDTO(AgencyUser agencyUser)
        {
            var agencyUserDto = new AgencyUserDTO
            {
                Id = agencyUser.Id,
                Agency = EntityUtils.AgencyToAgencyDTO(agencyUser.Agency),
                Username = agencyUser.Username,
                Password = agencyUser.Password,
                PhoneNumber = agencyUser.PhoneNumber
            };
            return agencyUserDto;
        }

        public static Agency DAgencytoAgency(DAgency dAgency)
        {
            var agency = new Agency
            {
                Id = dAgency.Id,
                AgencyName = dAgency.AgencyName,
                PhoneNumber = dAgency.PhoneNumber
            };
            return agency;
        }

        public static DAgency AgencyToDAgency(Agency agency)
        {
            var dAgency = new DAgency(agency.AgencyName, agency.PhoneNumber) { Id = agency.Id };
            return dAgency;
        }

        public static AgencyDTO AgencyToAgencyDTO(Agency agency)
        {
            var agencyDto = new AgencyDTO
            {
                Id = agency.Id,
                AgencyName = agency.AgencyName,
                PhoneNumber = agency.PhoneNumber
            };
            return agencyDto;
        }

        public static TripDTO TripToTripDTO(Trip trip)
        {
            return new TripDTO
            {
                Id = trip.Id,
                Agency = EntityUtils.AgencyToAgencyDTO(trip.Agency),
                DepartureLocation = trip.DepartureLocation,
                Destination = trip.Destination,
                DepartureTime = trip.DepartureTime,
                Duration = trip.Duration,
                Price = trip.Price,
                Seats = trip.Seats
            };
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
            var dRegularUser = new DRegularUser(regularUser.Username, regularUser.Password, regularUser.PhoneNumber, regularUser.FirstName, regularUser.LastName)
            {
                Id = regularUser.Id
            };
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

        public static RegularUserDTO RegularUserToRegularUserDTO(RegularUser r)
        {
            return new RegularUserDTO
            {
                Id = r.Id,
                Username = r.Username,
                Password = r.Password,
                FirstName = r.FirstName,
                LastName = r.LastName,
                PhoneNumber = r.PhoneNumber
            };
        }

        public static ReservationDTO ReservationToReservationDTO(Reservation r)
        {
            return new ReservationDTO
            {
                RegularUser = RegularUserToRegularUserDTO(r.RegularUser),
                Trip = TripToTripDTO(r.Trip),
                Seats = r.Seats
            };
        }
    }
}
