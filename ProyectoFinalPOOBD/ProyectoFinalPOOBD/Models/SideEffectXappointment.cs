#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class SideEffectXappointment
    {
        public bool IdAppointment { get; set; }
        public int IdSideEffect { get; set; }
        public int? Lapse { get; set; }

        public virtual Appointment IdAppointmentNavigation { get; set; }
        public virtual SideEffect IdSideEffectNavigation { get; set; }
    }
}
