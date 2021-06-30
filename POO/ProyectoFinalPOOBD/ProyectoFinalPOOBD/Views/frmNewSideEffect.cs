using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.Repository;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmNewSideEffect : Form
    {
        public frmNewSideEffect()
        {
            InitializeComponent();
        }

        // Esta funcion añade el nuevo efecto a la base de datos
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Se ejecuta si el efecto no es texto vacio
            if (txtSideEffect.Text != string.Empty)
            {
                var newSideEffec = new SideEffect();
                newSideEffec.Effect = txtSideEffect.Text;
                var context = new SideEffectServices();
                // Añadimos a la bd y cerramos
                context.Create(newSideEffec);
                this.Close();
            }
            else
            {
                // Sino se muestra la alerta
                MessageBox.Show("Por favor llene el campo del efecto secundario");
            }
        }
    }
}
