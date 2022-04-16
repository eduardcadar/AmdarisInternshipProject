using System;
using Xunit;
using FluentAssertions;
using Infrastructure;
using Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataAccess;
using Domain.Domain;
using System.Linq;

namespace InfrastructureTests
{
    public class TestTripDbReader : IDisposable
    {
        private readonly MicrobuzeContext _dbContext;
        private readonly ITripReader _reader;
        private readonly DAgency _agency;
        private readonly DAgencyUser _agencyUser;

        public TestTripDbReader()
        {
            var connectionString = @"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=" +
                "Microbuze" + Guid.NewGuid().ToString() + ";Trusted_Connection=True;";

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MicrobuzeContext>()
                .UseSqlServer(sqlConnectionStringBuilder.ConnectionString,
                options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

            _dbContext = new(dbContextOptionsBuilder.Options);
            _dbContext.Database.Migrate();
            _reader = new TripDbReader(_dbContext);

            _agency = new("agency", "0728182932");
            _dbContext.Agencies.Add(EntityUtils.DAgencytoAgency(_agency));
            _dbContext.SaveChanges();
            _agency.Id = 1;

            _agencyUser = new("username", "password", "0282923812", _agency);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void TestGetTripDtoById()
        {
            var trip = _agencyUser.CreateTrip("dep", "dest", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);
            _dbContext.Trips.Add(EntityUtils.DTripToTrip(trip));
            _dbContext.SaveChanges();
            var savedTrip = _dbContext.Trips.Single(t => t.AgencyId == _agency.Id);

            var tripDto = _reader.GetById(savedTrip.Id);
            var expectedTripDto = EntityUtils.TripToTripDTO(savedTrip);

            expectedTripDto.Should().BeEquivalentTo(tripDto);
        }

        [Fact]
        public void TestGetTripDtosFiltered()
        {

            var trip1 = _agencyUser.CreateTrip("cluj", "turda", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);
            var trip2 = _agencyUser.CreateTrip("cluj-napoca", "oradea", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);
            var trip3 = _agencyUser.CreateTrip("bacau", "onesti", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);
            _dbContext.Trips.Add(EntityUtils.DTripToTrip(trip1));
            _dbContext.Trips.Add(EntityUtils.DTripToTrip(trip2));
            _dbContext.Trips.Add(EntityUtils.DTripToTrip(trip3));
            _dbContext.SaveChanges();
            var savedTrips = _dbContext.Trips.ToList();

            var tripDtos = _reader.GetFiltered("cluj", "oradea");
            var expectedTripDtos = savedTrips
                .Where(t => t.DepartureLocation.Contains("cluj") && t.Destination.Contains("oradea"))
                .Select(t => EntityUtils.TripToTripDTO(t));

            expectedTripDtos.Should().BeEquivalentTo(tripDtos);
        }
    }
}
