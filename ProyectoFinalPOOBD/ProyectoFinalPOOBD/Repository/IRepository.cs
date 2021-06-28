using System.Collections.Generic;

namespace ProyectoFinalPOOBD.Repository
{
    // Interfaz utilizada como patron de diseño de tipo repositorio
    // Las operaciones basicas son GetAll que obtiene todos los datos de esa entidad en la BD
    // En si enfoca a todas las operaciones CRUD + la funcion Find que busca un dato segun el id
    interface IRepository<T>
    {
        List<T> GetAll();

        void Create(T item);

        void Update(T item);

        void Delete(T item);

        T Find(int pk);
    }
}
