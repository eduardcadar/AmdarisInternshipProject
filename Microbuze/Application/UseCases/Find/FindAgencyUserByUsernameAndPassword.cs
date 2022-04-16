using Domain.Domain;
using Domain.Repository;

namespace Application.UseCases.Find
{
    public class FindAgencyUserByUsernameAndPassword
    {
        private readonly IAgencyUserRepo _repo;

        public FindAgencyUserByUsernameAndPassword(IAgencyUserRepo repo)
        {
            _repo = repo;
        }

        public DAgencyUser Find(string username, string password)
            => _repo.GetByUsernameAndPassword(username, password);
    }
}
