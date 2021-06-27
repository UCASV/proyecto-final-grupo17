using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    class AppointmentXSideEffectsServices : IRepository<SideEffectXappointment>
    {
        private VaccinationContext _context = new VaccinationContext();
        public List<SideEffectXappointment> GetAll()
        {
            return new List<SideEffectXappointment>();
        }

        public void Create(SideEffectXappointment item)
        {
            _context.SideEffectXappointments.Add(item);
            _context.SaveChanges();
        }

        public void Update(SideEffectXappointment item)
        {
            _context.SideEffectXappointments.Update(item);
            _context.SaveChanges();
        }

        public void Delete(SideEffectXappointment item)
        {
            _context.SideEffectXappointments.Remove(item);
            _context.SaveChanges();
        }

        public SideEffectXappointment Find(int pk)
        {
            return new SideEffectXappointment();
        }
    }
}
