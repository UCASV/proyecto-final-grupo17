using System.Collections.Generic;

#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class Place
    {
        public Place()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string PlaceName { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
