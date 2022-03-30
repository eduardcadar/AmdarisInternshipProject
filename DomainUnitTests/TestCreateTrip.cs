using System;
using Application.Domain;
using Xunit;

namespace DomainUnitTests
{
    public class TestCreateTrip
    {
        [Fact]
        public void TestTrip()
        {
            User user = new("username", "password", "0777777777");
            Agency agency = new("agency", "0755555555");
            AgencyUser agencyUser = new(user, agency);
            Trip trip = agencyUser.CreateTrip("source", "dest", DateTime.Now.AddHours(1), TimeSpan.FromMinutes(60), 20.0, 20);
            Assert.Equal("source", trip.DepartureLocation);    
        }
    }
}
