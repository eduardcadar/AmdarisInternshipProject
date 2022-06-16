using Application.DTOs;
using Application.ReaderInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Readers
{
    public class AgencyUserDbReader : IAgencyUserReader
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyUserDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<AgencyUserDTO> GetById(string id, CancellationToken cancellationToken = default)
        {
            var agencyUser = await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Id.Equals(id), cancellationToken);
            if (agencyUser == null)
                return null;
            var agencyUserDto = EntityUtils.AgencyUserToAgencyUserDTO(agencyUser);
            return agencyUserDto;
        }
    }
}
