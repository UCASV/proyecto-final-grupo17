using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmLoadingView : Form
    {
        public frmLoadingView()
        {
            InitializeComponent();
            pbar.Value = 0;

        }

        private void tmrSideEffects_Tick(object sender, EventArgs e)//Se usa el timer para incrimentar el porcentaje de la barra de carga circular

        {
            pbar.Value += 1;
            pbar.Text = pbar.Value.ToString() + "%";
            if (pbar.Value == 100)
            {
                tmrSideEffects.Enabled = false;
                this.Close();
                //TODO Aca iria para que muestre el formulario de efectos secundarios
            }
        }
    }
}
