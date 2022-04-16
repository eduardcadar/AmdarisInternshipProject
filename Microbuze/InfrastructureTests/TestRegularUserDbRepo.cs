using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using Infrastructure;
using Domain.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataAccess;
using Domain.Domain;

namespace InfrastructureTests
{
    public class TestRegularUserDbRepo : IDisposable
    {
        private readonly MicrobuzeContext _dbContext;
        private readonly IRegularUserRepo _repo;

        public TestRegularUserDbRepo()
        {
            var connectionString = @"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=" +
                "Microbuze" + Guid.NewGuid().ToString() + ";Trusted_Connection=True;";

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MicrobuzeContext>()
                .UseSqlServer(sqlConnectionStringBuilder.ConnectionString,
                options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

            _dbContext = new(dbContextOptionsBuilder.Options);
            _dbContext.Database.Migrate();
            _repo = new RegularUserDbRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void TestAddRegularUser()
        {
            var regularUser = new DRegularUser("username", "password",
                "0728192382", "firstname", "lastname");

            _repo.Add(regularUser);
            var savedRegularUser = _dbContext.RegularUsers
                .Single(r => r.Username == regularUser.Username);
            var expectedRegularUser = EntityUtils.DRegularUserToRegularUser(regularUser);
            expectedRegularUser.Id = savedRegularUser.Id;
            expectedRegularUser.Reservations = savedRegularUser.Reservations;

            expectedRegularUser.Should().BeEquivalentTo(savedRegularUser);
        }

        [Fact]
        public void TestGetRegularUserByUsernameAndPassword()
        {
            var regularUser = new DRegularUser("username", "password",
                "0728192382", "firstname", "lastname");

            _repo.Add(regularUser);
            var savedRegularUser = _repo.GetByUsernameAndPassword(regularUser.Username, regularUser.Password);
            regularUser.Id = savedRegularUser.Id;

            regularUser.Should().BeEquivalentTo(savedRegularUser);
        }
    }
}
