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
    class AppointmentServices : IRepository<Appointment>
    {
        private VaccinationContext _context = new VaccinationContext();

        public List<Appointment> GetAll() => _context.Appointments.ToList();
        
        public void Create(Appointment item)
        {
            _context.Appointments.Add(item);
            _context.SaveChanges();
        }

        public void Update(Appointment item)
        {
            _context.Appointments.Update(item);
            _context.SaveChanges();
        }

        public void Delete(Appointment item)
        {
            _context.Appointments.Remove(item);
            _context.SaveChanges();
        }

        public Appointment Find(int pk) => _context.Appointments.FirstOrDefault(appointment => appointment.IdAppointment == pk);

        public List<Appointment> GetByCitizen(int citizenPk) =>
            _context.Appointments.Include(a => a.IdCitizenNavigation).Where(a => a.IdCitizenNavigation.Id.Equals(citizenPk)).ToList();

        public int GetLastIdVaccination() => _context.Appointments.Max(a => a.IdVaccination) ?? 0;

        public Appointment FillAppointment(Citizen person, Employee employee)
        {
            Random placeNumber = new();
            var placesAmount = new PlaceServices().Amount;
            var choosenPlace = placeNumber.Next(1, placesAmount);
            Place vaccinationPlace = new PlaceServices().GetById(choosenPlace);
            Appointment vaccineAppointment = new()
            {
                AppointmentDate = DateTime.Now.AddDays(7),
                IdPlace = vaccinationPlace.Id,
                IdPlaceNavigation = vaccinationPlace,
                IdCitizen = person.Id,
                IdCitizenNavigation = person,
                IdEmployee = employee.Id,
                IdEmployeeNavigation = employee
            };
            return vaccineAppointment;
        }
    }
}
