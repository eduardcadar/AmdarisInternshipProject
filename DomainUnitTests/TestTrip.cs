using System;
using Xunit;
using FluentAssertions;
using Domain.Domain;

namespace DomainUnitTests
{
    public class TestTrip
    {
        private readonly DAgencyUser agencyUser = new("username", "password", "0777777777", new DAgency("agency", "0234578723"));

        [Fact]
        public void TestCreateTripThrowsExceptionOnNullDepartureLocation()
        {
            string depLocation = null;

            Func<DTrip> func1 = () => agencyUser.CreateTrip(depLocation, "destination",
                DateTime.Now.AddHours(1), TimeSpan.FromMinutes(30), 20.3, 20);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateTripThrowsExceptionOnWhitespaceDepartureLocation()
        {
            string depLocation = " ";

            Func<DTrip> func1 = () => agencyUser.CreateTrip(depLocation, "destination",
                DateTime.Now.AddHours(1), TimeSpan.FromMinutes(30), 20.3, 20);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateTripThrowsExceptionOnNullDestination()
        {
            string destination = null;

            Func<DTrip> func1 = () => agencyUser.CreateTrip("depLocation", destination,
                DateTime.Now.AddHours(1), TimeSpan.FromMinutes(30), 20.3, 20);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateTripThrowsExceptionOnWhitespaceDestination()
        {
            string destination = " ";

            Func<DTrip> func1 = () => agencyUser.CreateTrip("depLocation", destination,
                DateTime.Now.AddHours(1), TimeSpan.FromMinutes(30), 20.3, 20);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateTripThrowsExceptionOnTooEarlyDepartureTime()
        {
            DateTime departureTime = DateTime.Now.AddMinutes(20);

            Func<DTrip> func1 = () => agencyUser.CreateTrip("depLocation", "destination",
                departureTime, TimeSpan.FromMinutes(30), 20.3, 20);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateTripThrowsExceptionOnNoDuration()
        {
            TimeSpan duration = TimeSpan.FromMinutes(0);

            Func<DTrip> func1 = () => agencyUser.CreateTrip("depLocation", "destination",
                DateTime.Now.AddHours(1), duration, 20.3, 20);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateTripThrowsExceptionOnNoPrice()
        {
            double price = -2;

            Func<DTrip> func1 = () => agencyUser.CreateTrip("depLocation", "destination",
                DateTime.Now.AddHours(1), TimeSpan.FromMinutes(30), price, 20);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateTripThrowsExceptionOnNoSeats()
        {
            int seats = 0;

            Func<DTrip> func1 = () => agencyUser.CreateTrip("depLocation", "destination",
                DateTime.Now.AddHours(1), TimeSpan.FromMinutes(30), 20.3, seats);

            func1.Should().Throw<ArgumentException>();
        }
    }
}
