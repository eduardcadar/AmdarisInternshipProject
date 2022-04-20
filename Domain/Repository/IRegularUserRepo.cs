using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRegularUserRepo
    {
        Task<DRegularUser> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken = default);
        Task<DRegularUser> Add(DRegularUser dRegularUser, CancellationToken cancellationToken = default);
    }
}
