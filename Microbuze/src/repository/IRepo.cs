using System.Collections.Generic;

namespace Microbuze.src.repository
{
    interface IRepo<T, Tid>
    {
        void Save(T elem);
        void update(T elem, Tid id);
        T GetById(Tid id);
        void Delete(T elem);
        void DeleteById(Tid id);
        ICollection<T> GetAll();
    }
}
