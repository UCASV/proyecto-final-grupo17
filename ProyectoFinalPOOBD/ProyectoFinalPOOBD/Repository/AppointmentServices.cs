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
        // Instanciacion del context como privado
        private VaccinationContext _context = new VaccinationContext();

        // Obtiene todos los datos
        public List<Appointment> GetAll() => _context.Appointments.ToList();
        
        // Crea una cita
        public void Create(Appointment item)
        {
            _context.Appointments.Add(item);
            _context.SaveChanges();
        }

        // Actualiza una cita/vacunacion
        public void Update(Appointment item)
        {
            _context.Appointments.Update(item);
            _context.SaveChanges();
        }

        // elimina una cita/vacunacion
        public void Delete(Appointment item)
        {
            _context.Appointments.Remove(item);
            _context.SaveChanges();
        }

        // Busca una cita por Id
        public Appointment Find(int pk) => _context.Appointments.FirstOrDefault(appointment => appointment.IdAppointment == pk);

        // Obtiene citas de un ciudadano
        public List<Appointment> GetByCitizen(int citizenPk) =>
            _context.Appointments.Include(a => a.IdCitizenNavigation).Where(a => a.IdCitizen == citizenPk).ToList();

        // Obtiene el ultimo id de vacunacion para simular esa columna como IDENTITY
        public int GetLastIdVaccination() => _context.Appointments.Max(a => a.IdVaccination) ?? 0;

        // Llena una cita pasando un ciudadano, un empleado y un bool que determina si es la primera cita
        public Appointment FillAppointment(Citizen person, Employee employee, bool firstTime)
        {
            // Creamos un random number
            Random placeNumber = new Random();

            // Obtenemos la cantidad de lugares
            var placesAmount = new PlaceServices().Amount;

            // Obtenemos el numero aleatorio
            var choosenPlace = placeNumber.Next(1, placesAmount);

            // Obtenemos el lugar escogido aleatoriamente
            Place vaccinationPlace = new Place();

            // daysToAdd es una variable que escoge la fecha en que se reserva cita para la vacunacion
            var daysToAdd = 0;
            DateTime vaccinationDate;

            // firsTime es un bool que es verdadero si es la primera vez, la cita por gustos personales puede ser dentro de 4 a 7 dias despues
            if (firstTime)
            {
                var amount = new PlaceServices().Amount;
                choosenPlace = placeNumber.Next(1, amount);

                // Reutilizando el random
                daysToAdd = placeNumber.Next(4, 7);
                vaccinationDate = DateTime.Now.AddDays(daysToAdd);
                
                vaccinationPlace = new PlaceServices().GetById(choosenPlace);
            }
            else
            {
                // Si no es la primera vez entonces se realiza de 6 a 8 semanas despues de la primera vacunacion
                daysToAdd = placeNumber.Next(6, 8) * 7;
                var appointment = _context.Appointments.OrderBy(a => a.IdAppointment)
                    .Include(p => p.IdPlaceNavigation).LastOrDefault(a => a.IdCitizen == person.Id);
                vaccinationDate = appointment.AppointmentDate;
                vaccinationDate = vaccinationDate.AddDays(daysToAdd);
                vaccinationPlace = appointment.IdPlaceNavigation;
            }

            // Llenamos la cita
            Appointment vaccineAppointment = new()
            {
                AppointmentDate = vaccinationDate,
                IdPlace = vaccinationPlace.Id,
                IdCitizen = person.Id,
                IdEmployee = employee.Id
            };
            return vaccineAppointment;
        }

        // Obtenemos la ultima cita de un ciudadano
        public Appointment GetLastByCitizen(int pk) => GetByCitizen(pk).LastOrDefault();
    }
}
