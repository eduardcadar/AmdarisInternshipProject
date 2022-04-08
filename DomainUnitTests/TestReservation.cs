using System;
using Xunit;
using FluentAssertions;
using Domain.Domain;

namespace DomainUnitTests
{

    public class TestReservation
    {
        private readonly DTrip trip = new DAgencyUser(
            "username", "password", "0777777777",
            new DAgency("agency", "0234578723"))
            .CreateTrip("depLocation", "destination", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 20.3, 20);
        private readonly DRegularUser regularUser = new DRegularUser(
            "username2", "password2", "0234678723", "firstname", "lastname");

        [Fact]
        public void TestCreateReservationThrowsExceptionOnNoSeats()
        {
            int seatsNumber = 0;

            Func<DReservation> func1 = () => regularUser.CreateReservation(trip, seatsNumber);

            func1.Should().Throw<ArgumentException>();
        }
    }
}
