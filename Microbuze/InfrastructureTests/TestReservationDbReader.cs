using System;
using System.Linq;
using Application.Interfaces;
using Domain.Domain;
using FluentAssertions;
using Infrastructure;
using Infrastructure.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InfrastructureTests
{
    public class TestReservationDbReader : IDisposable
    {
        private readonly MicrobuzeContext _dbContext;
        private readonly IReservationReader _reader;
        private readonly DAgency _agency;
        private readonly DAgencyUser _agencyUser;
        private readonly DTrip _trip1;
        private readonly DTrip _trip2;
        private readonly DTrip _trip3;
        private readonly DRegularUser _regularUser1;
        private readonly DRegularUser _regularUser2;
        private readonly DReservation _reservation1;
        private readonly DReservation _reservation2;
        private readonly DReservation _reservation3;
        private readonly DReservation _reservation4;

        public TestReservationDbReader()
        {
            var connectionString = @"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=" +
                "Microbuze" + Guid.NewGuid().ToString() + ";Trusted_Connection=True;";

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MicrobuzeContext>()
                .UseSqlServer(sqlConnectionStringBuilder.ConnectionString,
                options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

            _dbContext = new(dbContextOptionsBuilder.Options);
            _dbContext.Database.Migrate();
            _reader = new ReservationDbReader(_dbContext);
            _agency = new("agency2", "0727392132");
            _dbContext.Agencies.Add(EntityUtils.DAgencytoAgency(_agency));
            _dbContext.SaveChanges();
            _agency.Id = 1;

            _agencyUser = new("username", "password", "0222222222", _agency);

            _trip1 = _agencyUser.CreateTrip("dep", "dest", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);

            _trip2 = _agencyUser.CreateTrip("dep2", "dest2", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);

            _trip3 = _agencyUser.CreateTrip("dep3", "dest3", DateTime.Now.AddHours(1),
                TimeSpan.FromMinutes(30), 17.5, 20);
            
            _dbContext.Trips.Add(EntityUtils.DTripToTrip(_trip1));
            _dbContext.Trips.Add(EntityUtils.DTripToTrip(_trip2));
            _dbContext.Trips.Add(EntityUtils.DTripToTrip(_trip3));
            _dbContext.SaveChanges();
            _trip1.Id = 1;
            _trip2.Id = 2;
            _trip3.Id = 3;


            _regularUser1 = new("username", "password", "0728192382",
                "firstname", "lastname");

            _regularUser2 = new("username2", "password2", "0282192382",
                "firstname2", "lastname2");
            
            _dbContext.RegularUsers.Add(EntityUtils.DRegularUserToRegularUser(_regularUser1));
            _dbContext.RegularUsers.Add(EntityUtils.DRegularUserToRegularUser(_regularUser2));
            _dbContext.SaveChanges();
            _regularUser1.Id = 1;
            _regularUser2.Id = 2;

            _reservation1 = _regularUser1.CreateReservation(_trip1, 2);
            _reservation2 = _regularUser1.CreateReservation(_trip3, 2);
            _reservation3 = _regularUser2.CreateReservation(_trip2, 2);
            _reservation4 = _regularUser2.CreateReservation(_trip3, 2);

            _dbContext.Reservations.Add(EntityUtils.DReservationToReservation(_reservation1));
            _dbContext.Reservations.Add(EntityUtils.DReservationToReservation(_reservation2));
            _dbContext.Reservations.Add(EntityUtils.DReservationToReservation(_reservation3));
            _dbContext.Reservations.Add(EntityUtils.DReservationToReservation(_reservation4));
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void TestGetReservationsByRegularUserId()
        {
            var user1Reservations = _dbContext.Reservations
                .Where(r => r.RegularUserId == _regularUser1.Id)
                .Select(r => EntityUtils.ReservationToReservationDTO(r));

            var savedReservations = _reader.GetByRegularUserId(_regularUser1.Id);

            user1Reservations.Should().BeEquivalentTo(savedReservations);
        }

        [Fact]
        public void TestGetReservationsByTripId()
        {
            var trip3Reservations = _dbContext.Reservations
                .Where(r => r.TripId == _trip3.Id)
                .Select(r => EntityUtils.ReservationToReservationDTO(r));

            var savedReservations = _reader.GetByTripId(_trip3.Id);

            trip3Reservations.Should().BeEquivalentTo(savedReservations);
        }
    }
}
