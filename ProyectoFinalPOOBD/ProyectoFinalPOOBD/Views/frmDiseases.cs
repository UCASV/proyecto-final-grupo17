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
    public partial class frmDiseases : Form
    {
        public frmDiseases()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //TODO pendiente añadir nuevas enfermedades
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form newDisiease = new frmAddNewDisease();
            newDisiease.Show();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDone_Click(object sender, EventArgs e)
        {
            //Code for add the diesease
        }
    }
}
