using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAgencyUserRepo
    {
        Task<DAgencyUser> GetByUsername(string username, CancellationToken cancellationToken = default);
        Task<DAgencyUser> Add(DAgencyUser dAgencyUser, CancellationToken cancellationToken = default);
    }
}
