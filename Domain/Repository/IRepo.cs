using System.Collections.Generic;

namespace Domain.Repository
{
    interface IRepo<T, Tid>
    {
        void Add(T elem);
        void Update(T elem, Tid id);
        T GetById(Tid id);
        void Delete(T elem);
        void DeleteById(Tid id);
        ICollection<T> GetAll();
    }
}
