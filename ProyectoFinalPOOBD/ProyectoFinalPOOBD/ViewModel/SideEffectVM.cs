using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOOBD.ViewModel
{
    public class SideEffectVM
    {
        public string Effect { get; set; }
        public int Amount { get; set; }

        public SideEffectVM()
        {

        }

        public SideEffectVM(string Effect, int Amount)
        {
            this.Effect = Effect;
            this.Amount = Amount;
        }
        
    }
}
