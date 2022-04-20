using Xunit;
using FluentAssertions;
using Infrastructure;
using Domain.Repository;
using Microsoft.Data.SqlClient;
using System;
using Microsoft.EntityFrameworkCore;
using Domain.Domain;
using System.Threading.Tasks;
using Infrastructure.DataAccess.Repos;

namespace InfrastructureTests
{
    public class TestAgencyUserDbRepo : IDisposable
    {
        private readonly MicrobuzeContext _dbContext;
        private readonly IAgencyUserRepo _repo;

        public TestAgencyUserDbRepo()
        {
            var connectionString = @"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=" +
                "Microbuze" + Guid.NewGuid().ToString() + ";Trusted_Connection=True;";

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MicrobuzeContext>()
                .UseSqlServer(sqlConnectionStringBuilder.ConnectionString,
                options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

            _dbContext = new(dbContextOptionsBuilder.Options);
            _dbContext.Database.Migrate();
            _repo = new AgencyUserDbRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public async Task TestAddAgencyUser()
        {
            var agency = new DAgency("agency2", "0727392132");
            var agencyUser = new DAgencyUser("username", "password", "0222222222", agency);

            await _repo.Add(agencyUser);
            var savedAgencyUser = await _dbContext.AgencyUsers
                .SingleAsync(a => a.Username == agencyUser.Username);
            var expectedAgencyUser = EntityUtils.DAgencyUserToAgencyUser(agencyUser);
            expectedAgencyUser.Agency.Id = savedAgencyUser.Agency.Id;
            expectedAgencyUser.AgencyId = savedAgencyUser.AgencyId;
            expectedAgencyUser.Id = savedAgencyUser.Id;
            expectedAgencyUser.Agency.AgencyUsers = savedAgencyUser.Agency.AgencyUsers;

            expectedAgencyUser.Should().BeEquivalentTo(savedAgencyUser);
        }
        
        [Fact]
        public async Task TestGetAgencyUserByUsernameAndPassword()
        {
            var agency = new DAgency("agency", "0222222222");
            var agencyUser = new DAgencyUser("username", "password", "0222222222", agency);

            await _repo.Add(agencyUser);
            var savedAgencyUser = await _repo.GetByUsernameAndPassword(agencyUser.Username, agencyUser.Password);
            agencyUser.Id = savedAgencyUser.Id;
            agencyUser.Agency.Id = savedAgencyUser.Agency.Id;

            agencyUser.Should().BeEquivalentTo(savedAgencyUser);
        }
    }
}
