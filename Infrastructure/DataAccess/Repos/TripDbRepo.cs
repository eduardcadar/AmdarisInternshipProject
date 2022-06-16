using Domain.Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
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
            var agencyUser = EntityUtils.AgencyUserToDAgencyUser(await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Id.Equals(trip.AgencyUserId), cancellationToken));
            if (agencyUser == null)
                throw new RepositoryException("The agency doesn't exist");
            trip.AgencyUser = null;
            await _dbContext.Trips.AddAsync(trip, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            dTrip.AgencyUser = agencyUser;
            dTrip.Id = trip.Id;
            return dTrip;
        }

        public async Task Delete(int tripId, CancellationToken cancellationToken = default)
        {
            var trip = await _dbContext.Trips.
                SingleOrDefaultAsync(t => t.Id.Equals(tripId), cancellationToken);
            if (trip == null)
                throw new RepositoryException("No trip with this id");
            _dbContext.Trips.Remove(trip);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
