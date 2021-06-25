using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOOBD.ViewModel
{
    public class AppointmentVM
    {
        public string Name { get; set; }
        public int vaccination { get; set; }
        public AppointmentVM()
        {

        }
        public AppointmentVM(string Name, int vaccination)
        {
            this.Name = Name;
            this.vaccination = vaccination;
        }
    }
}
