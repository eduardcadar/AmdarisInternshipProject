using Domain.Domain;

namespace Domain.Repository
{
    public interface IRegularUserRepo
    {
        DRegularUser GetByUsernameAndPassword(string username, string password);
        void Add(DRegularUser dRegularUser);
    }
}
