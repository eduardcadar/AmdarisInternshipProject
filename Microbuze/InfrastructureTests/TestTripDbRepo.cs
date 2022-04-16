using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Domain.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataAccess;
using Domain.Domain;

namespace InfrastructureTests
{
    public class TestTripDbRepo : IDisposable
    {
        private readonly MicrobuzeContext _dbContext;
        private readonly ITripRepo _repo;
        private readonly DAgency _agency;
        private readonly DAgencyUser _agencyUser;

        public TestTripDbRepo()
        {
            var connectionString = @"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=" +
                "Microbuze" + Guid.NewGuid().ToString() + ";Trusted_Connection=True;";

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MicrobuzeContext>()
                .UseSqlServer(sqlConnectionStringBuilder.ConnectionString,
                options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

            _dbContext = new(dbContextOptionsBuilder.Options);
            _dbContext.Database.Migrate();
            _repo = new TripDbRepo(_dbContext);
            _agency = new DAgency("agency2", "0727392132");

            IAgencyRepo agencyRepo = new AgencyDbRepo(_dbContext);
            agencyRepo.Add(_agency);

            _agency.Id = 1;
            _agencyUser = new("username", "password", "0222222222", _agency);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void TestAddTrip()
        {
            var trip = _agencyUser.CreateTrip("dep", "dest", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);

            _repo.Add(trip);
            var savedTrip = _dbContext.Trips.Single(t => t.AgencyId == _agencyUser.Agency.Id);
            var expectedTrip = EntityUtils.DTripToTrip(trip);
            expectedTrip.Id = savedTrip.Id;
            expectedTrip.Agency = savedTrip.Agency;

            expectedTrip.Should().BeEquivalentTo(savedTrip);
        }
    }
}
