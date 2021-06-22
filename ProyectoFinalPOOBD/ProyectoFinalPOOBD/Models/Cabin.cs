using System.Collections.Generic;

#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class Cabin
    {
        public Cabin()
        {
            Logins = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}
