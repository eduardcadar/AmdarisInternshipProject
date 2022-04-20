using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;

namespace Domain.Repository
{
    public interface ITripRepo
    {
        Task Add(DTrip dTrip, CancellationToken cancellationToken = default);
    }
}
