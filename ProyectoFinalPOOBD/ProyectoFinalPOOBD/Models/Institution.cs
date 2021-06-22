﻿using System.Collections.Generic;

#nullable disable

namespace ProyectoFinalPOOBD.Models
{
    public partial class Institution
    {
        public Institution()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public string InstitutionName { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
