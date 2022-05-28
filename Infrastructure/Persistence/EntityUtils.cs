using Application.DTOs;
using Domain.Domain;
using Infrastructure.Persistence.Entities;

namespace Infrastructure
{
    public static class EntityUtils
    {
        public static DAgencyUser AgencyUserToDAgencyUser(AgencyUser agencyUser)
        {
            var dAgencyUser = new DAgencyUser(agencyUser.Username, agencyUser.PhoneNumber, agencyUser.Agency)
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
                Agency = agencyUser.Agency,
                Username = agencyUser.Username,
                PhoneNumber = agencyUser.PhoneNumber
            };
            return agencyUserDto;
        }

        public static DTrip TripToDTrip(Trip trip)
        {
            var dAgencyUser = AgencyUserToDAgencyUser(trip.AgencyUser);
            var dTrip = new DTrip(dAgencyUser, trip.DepartureLocation, trip.Destination,
                trip.DepartureTime, trip.Duration, trip.Price, trip.Seats)
            {
                Id = trip.Id
            };
            return dTrip;
        }

        public static TripDTO TripToTripDTO(Trip trip)
        {
            var agencyUserDTO = AgencyUserToAgencyUserDTO(trip.AgencyUser);
            return new TripDTO
            {
                Id = trip.Id,
                AgencyUser = agencyUserDTO,
                DepartureLocation = trip.DepartureLocation,
                Destination = trip.Destination,
                DepartureTime = trip.DepartureTime,
                Duration = trip.Duration,
                Price = trip.Price,
                SeatsLeft = trip.Seats
            };
        }

        public static Trip DTripToTrip(DTrip dTrip)
        {
            var trip = new Trip
            {
                Id = dTrip.Id,
                AgencyUserId = dTrip.AgencyUser.Id,
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
            var dRegularUser = new DRegularUser(regularUser.Username, regularUser.PhoneNumber, regularUser.FirstName, regularUser.LastName)
            {
                Id = regularUser.Id
            };
            return dRegularUser;
        }

        public static Reservation DReservationToReservation(DReservation dReservation)
        {
            var reservation = new Reservation
            {
                RegularUserId = dReservation.RegularUser.Id,
                TripId = dReservation.Trip.Id,
                Seats = dReservation.Seats
            };
            return reservation;
        }

        public static AgencyUser DAgencyUserToAgencyUser(DAgencyUser dAgencyUser)
        {
            var agencyUser = new AgencyUser {
                Id = dAgencyUser.Id,
                Agency = dAgencyUser.Agency,
                Username = dAgencyUser.Username,
                PhoneNumber = dAgencyUser.PhoneNumber
            };
            return agencyUser;
        }

        public static RegularUserDTO RegularUserToRegularUserDTO(RegularUser r)
        {
            return new RegularUserDTO
            {
                Id = r.Id,
                Username = r.Username,
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
