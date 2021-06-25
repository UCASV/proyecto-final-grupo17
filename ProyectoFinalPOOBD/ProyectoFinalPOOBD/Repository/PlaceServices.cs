using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    class PlaceServices
    {
        
        private VaccinationContext _context = new VaccinationContext();
        public int Amount => GetAllPlaces().Count;
        public List<Place> GetAllPlaces() => _context.Places.ToList();
        public Place GetById(int pk) => _context.Places.Find(pk);
    }
}
