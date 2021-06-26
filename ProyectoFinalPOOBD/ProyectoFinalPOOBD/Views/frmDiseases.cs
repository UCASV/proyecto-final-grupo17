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
        public List<Disease>? Diseases { get; set; }
       
        public frmDiseases()
        {
            InitializeComponent();
            Diseases = new List<Disease>();
        }

        public frmDiseases(List<Disease>? diseases)
        {
            InitializeComponent();
            Diseases = diseases;
            FillDgv();
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
            dgvDiseases.DataSource = Diseases.Select(s=> new {s.Illness}).ToList();
        }

        public List<Disease>? ReturnList => Diseases;

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Las enfermedades han sido añadidas al formulario.");
            this.Close();
        }

        // Al dar click al boton eliminar removera la enfermedad de la lista y el datagridview
        private void dgvDiseases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si la celda pertenece a la columna con el nombre Eliminar, removera la enfermedad pasando el index en el que esta en el dgv al coincidir en la lista
            if (dgvDiseases.Columns[e.ColumnIndex].HeaderText == "Eliminar")
            {
                // Eliminamos y repoblamos el datagridview
                Diseases.RemoveAt(e.RowIndex);
                FillDgv();
            }
        }
    }
}
