using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    // Algunas consultas de instituciones pero no implementa IRepository debido a que no se usan muchas de las opciones
    class InstitutionServices
    {
        private VaccinationContext _context = new VaccinationContext();

        public List<Institution> GetAllInstitutions()
        {
            return _context.Institutions.ToList();
        }

        // Se obtienen todas las instituciones menos la opcion de ninguna
        public List<Institution> GetInstitutions()
        {
            return _context.Institutions.Where(institution => institution.InstitutionName != "Ninguna").ToList();
        }

        public Institution Find(int pk)
        {
            return _context.Institutions.Find(pk);
        }
    }
}
