using System;
using Xunit;
using FluentAssertions;
using Domain.Repository;
using Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Domain.Domain;
using System.Threading.Tasks;
using Infrastructure.DataAccess.Repos;

namespace InfrastructureTests
{
    public class TestReservationDbRepo : IDisposable
    {
        private readonly MicrobuzeContext _dbContext;
        private readonly IReservationRepo _repo;
        private readonly DAgency _agency;
        private readonly DAgencyUser _agencyUser;
        private readonly DTrip _trip;
        private readonly DRegularUser _regularUser;

        public TestReservationDbRepo()
        {
            var connectionString = @"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=" +
                "Microbuze" + Guid.NewGuid().ToString() + ";Trusted_Connection=True;";

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MicrobuzeContext>()
                .UseSqlServer(sqlConnectionStringBuilder.ConnectionString,
                options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

            _dbContext = new(dbContextOptionsBuilder.Options);
            _dbContext.Database.Migrate();
            _repo = new ReservationDbRepo(_dbContext);

            _agency = new("agency2", "0727392132");
            IAgencyRepo agencyRepo = new AgencyDbRepo(_dbContext);
            agencyRepo.Add(_agency);
            _agency.Id = 1;

            _agencyUser = new("username", "password", "0222222222", _agency);

            _trip = _agencyUser.CreateTrip("dep", "dest", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);
            ITripRepo tripRepo = new TripDbRepo(_dbContext);
            tripRepo.Add(_trip);
            _trip.Id = 1;

            _regularUser = new("username", "password", "0728192382",
                "firstname", "lastname");
            IRegularUserRepo regularUserRepo = new RegularUserDbRepo(_dbContext);
            regularUserRepo.Add(_regularUser);
            _regularUser.Id = 1;
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public async Task TestAddReservation()
        {
            var reservation = _regularUser.CreateReservation(_trip, 3);

            await _repo.Add(reservation);
            var savedReservation = await _dbContext.Reservations
                .SingleAsync(r => r.RegularUser.Username.Equals(_regularUser.Username)
                    && r.Trip.AgencyId.Equals(_agency.Id));
            var expectedReservation = EntityUtils.DReservationToReservation(reservation);
            expectedReservation.RegularUser = savedReservation.RegularUser;
            expectedReservation.Trip = savedReservation.Trip;

            expectedReservation.Should().BeEquivalentTo(savedReservation);
        }
    }
}
