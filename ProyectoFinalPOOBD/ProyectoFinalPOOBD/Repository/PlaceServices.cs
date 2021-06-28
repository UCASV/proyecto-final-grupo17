using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    // No se utiliza IRepository ya que no realizamos todas las operaciones CRUD
    class PlaceServices
    {
        // Instacianciamos al context
        private VaccinationContext _context = new VaccinationContext();

        public PlaceServices()
        {
            
        }

        // Funcion que devuelve la cantidad de lugares
        public int Amount => _context.Places.Count();

        // Obtiene todos los lugares
        public List<Place> GetAllPlaces() => _context.Places.ToList();

        // Se obtiene el lugar segun el id
        public Place GetById(int pk) => _context.Places.Find(pk);
    }
}
