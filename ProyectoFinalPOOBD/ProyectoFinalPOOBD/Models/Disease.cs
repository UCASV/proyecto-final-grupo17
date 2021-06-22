#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class Disease
    {
        public int Id { get; set; }
        public string Illness { get; set; }
        public int? IdCitizen { get; set; }

        public virtual Citizen IdCitizenNavigation { get; set; }
    }
}
