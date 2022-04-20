using Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReaderInterfaces
{
    public interface IAgencyReader
    {
        Task<AgencyDTO> GetById(int id, CancellationToken cancellationToken = default);
    }
}
