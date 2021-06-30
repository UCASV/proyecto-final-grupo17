using System.Collections.Generic;

#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class SideEffect
    {
        public SideEffect()
        {
            SideEffectXappointments = new HashSet<SideEffectXappointment>();
        }

        public int Id { get; set; }
        public string Effect { get; set; }

        public virtual ICollection<SideEffectXappointment> SideEffectXappointments { get; set; }
    }
}
