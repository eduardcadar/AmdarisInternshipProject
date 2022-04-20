using Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReaderInterfaces
{
    public interface IRegularUserReader
    {
        Task<RegularUserDTO> GetById(int id, CancellationToken cancellationToken = default);
    }
}
