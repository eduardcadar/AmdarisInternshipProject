using Application.ReaderInterfaces;
using Application.DTOs;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Domain.Repository;

namespace Infrastructure.DataAccess.Readers
{
    public class AgencyDbReader : IAgencyReader
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<AgencyDTO> GetById(int id, CancellationToken cancellationToken = default)
        {
            var agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.Id == id, cancellationToken);
            if (agency == null)
                return null;
            var agencyDto = new AgencyDTO
            {
                Id = agency.Id,
                AgencyName = agency.AgencyName,
                PhoneNumber = agency.PhoneNumber
            };
            return agencyDto;
        }
    }
}
