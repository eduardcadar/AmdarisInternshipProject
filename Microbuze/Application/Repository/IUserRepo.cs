using Application.Domain;

namespace Application.Repository
{
    public interface IUserRepo
    {
        public void Save(User user);
        public User Get(int id);
    }
}
