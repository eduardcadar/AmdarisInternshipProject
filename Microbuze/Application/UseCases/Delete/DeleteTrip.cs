using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Delete
{
    public class DeleteTrip
    {
        public readonly ITripRepo _tripRepo;

        public DeleteTrip(ITripRepo tripRepo)
        {
            _tripRepo = tripRepo;
        }

        public async Task Delete(int tripId, CancellationToken cancellationToken = default)
            => await _tripRepo.Delete(tripId, cancellationToken);
    }
}
