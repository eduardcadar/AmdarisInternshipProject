using Application.Domain;

namespace Application.Repository
{
    public interface IRegularUserRepo
    {
        public RegularUser Get(int id);
    }
}
