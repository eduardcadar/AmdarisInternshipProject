using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAgencyRepo
    {
        Task<DAgency> Add(DAgency dAgency, CancellationToken cancellationToken = default);
        Task<DAgency> GetByName(string agencyName, CancellationToken cancellationToken = default);
    }
}
