using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            SideEffectXappointments = new HashSet<SideEffectXappointment>();
        }

        public int IdAppointment { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int? IdVaccination { get; set; }
        public TimeSpan? WaitingDateTime { get; set; }
        public DateTime? VaccineDateTime { get; set; }
        public int IdCitizen { get; set; }
        public int? IdEmployee { get; set; }
        public int IdPlace { get; set; }

        public virtual Citizen IdCitizenNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Place IdPlaceNavigation { get; set; }
        public virtual ICollection<SideEffectXappointment> SideEffectXappointments { get; set; }
    }
}
