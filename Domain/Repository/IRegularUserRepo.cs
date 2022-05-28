using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRegularUserRepo
    {
        Task<DRegularUser> GetByUsername(string username, CancellationToken cancellationToken = default);
        Task<DRegularUser> Add(DRegularUser dRegularUser, CancellationToken cancellationToken = default);
    }
}
