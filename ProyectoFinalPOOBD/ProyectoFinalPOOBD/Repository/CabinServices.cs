using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    class CabinServices : IRepository<Cabin>
    {
        private VaccinationContext _context = new VaccinationContext();
        public List<Cabin> GetAll()
        {
            return _context.Cabins.ToList();
        }

        public void Create(Cabin item)
        {
            _context.Cabins.Add(item);
            _context.SaveChanges();
        }

        public void Update(Cabin item)
        {
            _context.Cabins.Update(item);
            _context.SaveChanges();
        }

        public void Delete(Cabin item)
        {
            _context.Cabins.Remove(item);
            _context.SaveChanges();
        }

        public Cabin Find(int pk)
        {
            return _context.Cabins.FirstOrDefault(cabin => cabin.Id == pk);
        }
    }
}
