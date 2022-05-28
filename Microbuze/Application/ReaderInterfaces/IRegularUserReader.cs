using Application.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReaderInterfaces
{
    public interface IRegularUserReader
    {
        Task<RegularUserDTO> GetById(string regularUserId, CancellationToken cancellationToken = default);
    }
}
