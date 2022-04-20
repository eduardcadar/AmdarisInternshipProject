using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAgencyUserRepo
    {
        Task<DAgencyUser> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken = default);
        Task<DAgencyUser> Add(DAgencyUser dAgencyUser, CancellationToken cancellationToken = default);
    }
}
