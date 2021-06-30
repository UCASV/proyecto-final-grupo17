using System.Collections.Generic;
using ProyectoFinalPOOBD.VaccineContext;

#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Appointments = new HashSet<Appointment>();
            Logins = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public int? IdUser { get; set; }
        public int? IdCabin { get; set; }
        public int? IdEmployeeType { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual EmployeeType IdEmployeeTypeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}
