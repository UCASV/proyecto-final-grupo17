using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    class InstitutionServices
    {
        private VaccinationContext _context = new VaccinationContext();

        public List<Institution> GetAllInstitutions()
        {
            return _context.Institutions.ToList();
        }

        public List<Institution> GetInstitutions()
        {
            return _context.Institutions.Where(institution => institution.InstitutionName != "Ninguna").ToList();
        }
    }
}
