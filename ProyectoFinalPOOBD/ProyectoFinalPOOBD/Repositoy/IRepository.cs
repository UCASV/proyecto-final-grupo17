using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOOBD.Repositoy
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
