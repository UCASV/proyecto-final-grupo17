using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    class SideEffectServices : IRepository<SideEffect>
    {
        private VaccinationContext _context = new VaccinationContext();
        public List<SideEffect> GetAll() => _context.SideEffects.ToList();

        public void Create(SideEffect item)
        {
            _context.SideEffects.Add(item);
            _context.SaveChanges();
        }

        public void Update(SideEffect item)
        {
            _context.SideEffects.Update(item);
            _context.SaveChanges();
        }

        public void Delete(SideEffect item)
        {
            _context.SideEffects.Remove(item);
            _context.SaveChanges();
        }

        public SideEffect Find(int pk) => _context.SideEffects.Find(pk);
    }
}
