using System.Collections.Generic;
using Domain.Domain;

namespace Domain.Repository
{
    public interface IAgencyRepo
    {
        public void Save(Agency agency);
        public ICollection<Agency> GetAll();
    }
}
