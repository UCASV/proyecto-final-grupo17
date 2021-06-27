using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            _context.Appointments.Include(a => a.IdCitizenNavigation).Where(a => a.IdCitizen == citizenPk).ToList();

        public int GetLastIdVaccination() => _context.Appointments.Max(a => a.IdVaccination) ?? 0;

        public Appointment FillAppointment(Citizen person, Employee employee, bool firstTime)
        {
            Random placeNumber = new Random();
            var placesAmount = new PlaceServices().Amount;
            var choosenPlace = placeNumber.Next(1, placesAmount);
            Place vaccinationPlace = new PlaceServices().GetById(choosenPlace);

            // daysToAdd es una variable que escoge la fecha en que se reserva cita para la vacunacion
            var daysToAdd = 0;
            DateTime vaccinationDate;

            // firsTime es un bool que es verdadero si es la primera vez, la cita por gustos personales puede ser dentro de 4 a 7 dias despues
            if (firstTime)
            {
                daysToAdd = placeNumber.Next(4, 7);
                vaccinationDate = DateTime.Now.AddDays(daysToAdd);

            }
            else
            {
                // Si no es la primera vez entonces se realiza de 6 a 8 semanas despues de la primera vacunacion
                daysToAdd = placeNumber.Next(6, 8) * 7;
                vaccinationDate = _context.Appointments.OrderBy(a => a.IdAppointment).LastOrDefault(a => a.IdCitizen == person.Id).AppointmentDate;
                vaccinationDate = vaccinationDate.AddDays(daysToAdd);
            }

            Appointment vaccineAppointment = new()
            {
                AppointmentDate = vaccinationDate,
                IdPlace = vaccinationPlace.Id,
                IdCitizen = person.Id,
                IdEmployee = employee.Id
            };
            return vaccineAppointment;
        }

        public Appointment GetLastByCitizen(int pk) => GetByCitizen(pk).LastOrDefault();

        public List<Appointment> CitizensWithAppointments()
        {
            var citizens = _context.Citizens.Include(c => c.Appointments)
                .Where(c => c.Appointments.Count == 1 && c.Appointments.First().IdVaccination == null).ToList();

            var ids = citizens.Select(c => new { c.Id }).ToList();
            List<int> idsList = new List<int>();
            ids.ForEach(i => idsList.Add(i.Id));

            var appointments1 = _context.Appointments.Include(a => a.IdCitizenNavigation)
                .Where(a => idsList.Contains(a.IdCitizen)).ToList();

            var citizensSecondAppointment = _context.Citizens.Include(c => c.Appointments)
                .Where(c => c.Appointments.Count == 2 && c.Appointments.OrderBy(a => a.IdAppointment).Last().IdVaccination == null).ToList();

            var idsSecondAppointment = citizensSecondAppointment.Select(c => new { c.Id }).ToList();
            List<int> secondIdList = new List<int>();
            idsSecondAppointment.ForEach(i => secondIdList.Add(i.Id));

            var appointments2 = _context.Appointments.Include(a => a.IdCitizenNavigation)
                .Where(a => secondIdList.Contains(a.IdCitizen)).ToList();

            appointments1.AddRange(appointments2);
            return appointments1;
        }
    }
}
