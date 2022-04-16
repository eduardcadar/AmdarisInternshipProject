using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using Infrastructure;
using Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataAccess;
using Infrastructure.Persistence.Entities;

namespace InfrastructureTests
{
    public class TestAgencyDbReader : IDisposable
    {
        private readonly MicrobuzeContext _dbContext;
        private readonly IAgencyReader _reader;

        public TestAgencyDbReader()
        {
            var connectionString = @"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=" +
                "Microbuze" + Guid.NewGuid().ToString() + ";Trusted_Connection=True;";

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MicrobuzeContext>()
                .UseSqlServer(sqlConnectionStringBuilder.ConnectionString,
                options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));

            _dbContext = new(dbContextOptionsBuilder.Options);
            _dbContext.Database.Migrate();
            _reader = new AgencyDbReader(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void TestGetAgencyDtoById()
        {
            var agency = new Agency
            {
                AgencyName = "agency",
                PhoneNumber = "0728129382"
            };
            _dbContext.Agencies.Add(agency);
            _dbContext.SaveChanges();
            var savedAgency = _dbContext.Agencies.Single(a => a.AgencyName.Equals(agency.AgencyName));

            var agencyDto = _reader.GetById(savedAgency.Id);
            var expectedAgencyDto = EntityUtils.AgencyToAgencyDTO(savedAgency);

            expectedAgencyDto.Should().BeEquivalentTo(agencyDto);
        }
    }
}
