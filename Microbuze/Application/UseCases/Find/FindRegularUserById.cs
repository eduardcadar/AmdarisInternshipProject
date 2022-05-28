using Application.DTOs;
using Application.ReaderInterfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Find
{
    public class FindRegularUserById
    {
        private readonly IRegularUserReader _reader;

        public FindRegularUserById(IRegularUserReader reader)
        {
            _reader = reader;
        }

        public async Task<RegularUserDTO> Find(string regularUserId, CancellationToken cancellationToken = default)
        {
            var regularUserDto = await _reader.GetById(regularUserId, cancellationToken);
            return regularUserDto;
        }
    }
}
