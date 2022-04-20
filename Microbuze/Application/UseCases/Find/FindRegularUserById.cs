using Application.Models;
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

        public async Task<RegularUserDTO> Find(int id, CancellationToken cancellationToken = default)
        {
            var regularUserDto = await _reader.GetById(id, cancellationToken);
            return regularUserDto;
        }
    }
}
