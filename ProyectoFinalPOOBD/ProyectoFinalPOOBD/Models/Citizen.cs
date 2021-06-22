using System.Collections.Generic;

#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class Citizen
    {
        public Citizen()
        {
            Appointments = new HashSet<Appointment>();
            Diseases = new HashSet<Disease>();
        }

        public int Id { get; set; }
        public string Dui { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int? IdInstitution { get; set; }

        public virtual Institution IdInstitutionNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
