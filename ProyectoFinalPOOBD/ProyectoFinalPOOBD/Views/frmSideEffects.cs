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
using ProyectoFinalPOOBD.ViewModel;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmSideEffects : Form
    {
        public List<ViewModel.SideEffectXAppointmentVm> SideEffects { get; set; }
        public List<SideEffect> Effects { get; set; }
        public List<SideEffect> DgvEffects { get; set; }
        

        public frmSideEffects()
        {
            InitializeComponent();
            SideEffects = new List<SideEffectXAppointmentVm>();
            InitializeCmbBox();
        }

        public void InitializeCmbBox()
        {
            Effects = new SideEffectServices().GetAll();
            cmbEffects.DataSource = Effects;
            cmbEffects.DisplayMember = "Effect";
            cmbEffects.ValueMember = "Id";
            DgvEffects = new List<SideEffect>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (txtMins.Text != string.Empty)
                {
                    var sideEffectVm = new SideEffectXAppointmentVm();
                    sideEffectVm.SideEffectId = (int) cmbEffects.SelectedValue;
                    var effectSelectedItem = ((SideEffect) cmbEffects.SelectedItem).Effect;

                    try
                    {
                        sideEffectVm.Lapse = Int32.Parse(txtMins.Text);
                        SideEffects.Add(sideEffectVm);

                        SideEffect effect = new SideEffect();
                        effect.Effect = effectSelectedItem;
                        DgvEffects.Add(effect);
                        dgvEffects.DataSource = DgvEffects.Select(e => new { Effect = e.Effect } ).ToList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El dato ingresado no es un numero");
                    }
                }
                else
                {
                    MessageBox.Show("El campo de minutos esta vacio, por favor ingrese un minuto");
                }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            var newSideEffect = new frmNewSideEffect();
            newSideEffect.ShowDialog();
            InitializeCmbBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNo.Checked)
            {
                cmbEffects.Enabled = false;
                txtMins.Enabled = false;
                btnAddEffect.Enabled = false;
                lblLink.Enabled = false;
                btnAddEffect.Enabled = false;
            }
        }

        private void rdoYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoYes.Checked)
            {
                cmbEffects.Enabled = true;
                txtMins.Enabled = true;
                btnAddEffect.Enabled = true;
                lblLink.Enabled = true;
                btnAddEffect.Enabled = true;
            }
        }
    }
}
