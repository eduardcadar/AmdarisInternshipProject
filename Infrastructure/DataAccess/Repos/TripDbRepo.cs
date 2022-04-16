using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    public class TripDbRepo : ITripRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public TripDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(DTrip dTrip)
        {
            var trip = EntityUtils.DTripToTrip(dTrip);
            _dbContext.Trips.Add(trip);
            _dbContext.SaveChanges();
        }
    }
}
