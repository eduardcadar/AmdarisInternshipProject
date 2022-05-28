using Application.DTOs;
using Application.ReaderInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Readers
{
    public class RegularUserDbReader : IRegularUserReader
    {
        private readonly MicrobuzeContext _dbContext;

        public RegularUserDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<RegularUserDTO> GetById(string regularUserId, CancellationToken cancellationToken = default)
        {

            var regularUser = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Id.Equals(regularUserId), cancellationToken);
            if (regularUser == null)
                return null;
            var regularUserDto = EntityUtils.RegularUserToRegularUserDTO(regularUser);
            return regularUserDto;
        }
    }
}
