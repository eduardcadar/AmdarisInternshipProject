using System;
using System.Collections.Generic;
using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    class AgencyRepo : IAgencyRepo
    {
        public ICollection<Agency> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Agency agency)
        {
            throw new NotImplementedException();
        }
    }
}
