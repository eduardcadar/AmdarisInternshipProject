using Domain.Domain;
using Domain.Repository;

namespace Application.UseCases.Create
{
    public class CreateRegularUser
    {
        private readonly IRegularUserRepo _repo;

        public CreateRegularUser(IRegularUserRepo repo)
        {
            _repo = repo;
        }

        public void Create(string username, string password, string phoneNumber,
            string firstName, string lastName)
        {
            var dRegularUser = new DRegularUser(username, password, phoneNumber,
                firstName, lastName);
            _repo.Add(dRegularUser);
        }
    }
}
