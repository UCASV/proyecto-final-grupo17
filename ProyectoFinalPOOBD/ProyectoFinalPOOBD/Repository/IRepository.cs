using System.Collections.Generic;

namespace ProyectoFinalPOOBD.Repository
{
    interface IRepository<T>
    {
        List<T> GetAll();

        void Create(T item);

        void Update(T item);

        void Delete(T item);

        T Find(int pk);
    }
}
