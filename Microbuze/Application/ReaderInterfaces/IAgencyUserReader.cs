using Application.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReaderInterfaces
{
    public interface IAgencyUserReader
    {
        Task<AgencyUserDTO> GetById(int id, CancellationToken cancellationToken = default);
    }
}
