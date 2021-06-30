using System;

#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public DateTime LoginDate { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdCabin { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
