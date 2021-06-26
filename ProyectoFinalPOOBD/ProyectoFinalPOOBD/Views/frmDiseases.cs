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
using String = System.String;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmDiseases : Form
    {
        public List<Disease> Diseases { get; set; }
       
        public frmDiseases()
        {
            InitializeComponent();
            Diseases = new List<Disease>();
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //TODO pendiente añadir nuevas enfermedades
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDisease.Text != String.Empty)
            {
                var newDisease = new Disease()
                {
                    Illness = txtDisease.Text
                };

                Diseases.Add(newDisease);

                FillDgv();
            }
        }

        private void FillDgv()
        {
            dgvDiseases.DataSource = null;
            dgvDiseases.DataSource = Diseases.Select(s=> new {Enfermedad = s.Illness}).ToList();
        }

        public List<Disease>? ReturnList => Diseases;

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
