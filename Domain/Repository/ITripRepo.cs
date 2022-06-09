using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;

namespace Domain.Repository
{
    public interface ITripRepo
    {
        Task<DTrip> Add(DTrip dTrip, CancellationToken cancellationToken = default);
        Task Delete(int tripId, CancellationToken cancellationToken = default);
    }
}
