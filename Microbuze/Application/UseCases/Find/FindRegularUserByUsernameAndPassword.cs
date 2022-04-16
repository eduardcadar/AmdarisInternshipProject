using Domain.Domain;
using Domain.Repository;

namespace Application.UseCases.Find
{
    public class FindRegularUserByUsernameAndPassword
    {
        private readonly IRegularUserRepo _repo;

        public FindRegularUserByUsernameAndPassword(IRegularUserRepo repo)
        {
            _repo = repo;
        }

        public DRegularUser Find(string username, string password)
            => _repo.GetByUsernameAndPassword(username, password);
    }
}
