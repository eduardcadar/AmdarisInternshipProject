using Domain.Domain;
using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repos
{
    public class TripDbRepo : ITripRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public TripDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<DTrip> Add(DTrip dTrip, CancellationToken cancellationToken = default)
        {
            var trip = EntityUtils.DTripToTrip(dTrip);
            await _dbContext.Trips.AddAsync(trip, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            dTrip.Id = trip.Id;
            return dTrip;
        }
    }
}
