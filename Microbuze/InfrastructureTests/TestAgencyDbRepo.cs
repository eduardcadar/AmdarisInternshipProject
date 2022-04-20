using System;
using Domain.Domain;
using Domain.Repository;
using Infrastructure;
using Xunit;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Infrastructure.DataAccess.Repos;

namespace InfrastructureTests
{
    public class TestAgencyDbRepo : IDisposable
    {
        private readonly MicrobuzeContext _dbContext;
        private readonly IAgencyRepo _repo;

        public TestAgencyDbRepo()
        {
            var connectionString = @"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=" +
                "Microbuze" + Guid.NewGuid().ToString() + ";Trusted_Connection=True;";

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MicrobuzeContext>()
                .UseSqlServer(sqlConnectionStringBuilder.ConnectionString,
                options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

            _dbContext = new(dbContextOptionsBuilder.Options);
            _dbContext.Database.Migrate();
            _repo = new AgencyDbRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public async Task TestAddAgency()
        {
            var agency = new DAgency("agency", "0728392192");

            await _repo.Add(agency);
            var savedAgency = await _dbContext.Agencies.SingleAsync(a => a.AgencyName == "agency");
            var expectedAgency = EntityUtils.DAgencytoAgency(agency);
            expectedAgency.Id = savedAgency.Id;

            expectedAgency.Should().BeEquivalentTo(savedAgency);
        }

        [Fact]
        public async Task TestGetAgency()
        {
            var agency = new DAgency("agency", "0222222222");

            await _repo.Add(agency);
            var savedAgency = await _repo.GetByName(agency.AgencyName);
            agency.Id = savedAgency.Id;

            agency.Should().BeEquivalentTo(savedAgency);
        }
    }
}
