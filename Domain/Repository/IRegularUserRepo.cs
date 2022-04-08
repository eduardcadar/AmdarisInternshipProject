using Domain.Domain;

namespace Domain.Repository
{
    public interface IRegularUserRepo
    {
        public DRegularUser Get(int id);
    }
}
