using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    class CitizenServices : IRepository<Citizen>
    {

        private VaccinationContext _context = new VaccinationContext();

        public List<Citizen> GetAll()
        {
            return _context.Citizens.ToList();
        }

        public void Create(Citizen item)
        {
            _context.Citizens.Add(item);
            _context.SaveChanges();
        }

        public void Update(Citizen item)
        {
            _context.Citizens.Update(item);
            _context.SaveChanges();
        }

        public void Delete(Citizen item)
        {
            _context.Citizens.Remove(item);
            _context.SaveChanges();
        }

        public Citizen Find(int pk)
        {
            return _context.Citizens.FirstOrDefault(citizen => citizen.Id.Equals(pk));
        }

        public Citizen GetLastCitizen()
        {
            return _context.Citizens.OrderBy(c => c.Id).LastOrDefault();
        }

        public Citizen GetCitizenByDui(string dui)
        {
            return _context.Citizens.FirstOrDefault(citizen => citizen.Dui == dui);
        }
    }
}