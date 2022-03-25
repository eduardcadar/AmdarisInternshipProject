using Domain.Domain;

namespace Domain.Repository
{
    public interface IUserRepo
    {
        public void Save(User user);
        public User GetById(int id);
    }
}
