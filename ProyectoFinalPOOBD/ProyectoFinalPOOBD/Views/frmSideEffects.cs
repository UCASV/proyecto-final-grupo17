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
        // lista que contendra el id del efecto secundario y el efecto
        public List<ViewModel.SideEffectXAppointmentVm> SideEffects { get; set; }
        // Lista que contendra los efectos secundarios de la bd
        public List<SideEffect> Effects { get; set; }

        // Lista que usara el datagridview
        public List<SideEffect> DgvEffects { get; set; }
        public List<int> IdEffectsToRemove { get; set; }

        public frmSideEffects()
        {
            InitializeComponent();
            SideEffects = new List<SideEffectXAppointmentVm>();
            InitializeCmbBox();
            DgvEffects = new List<SideEffect>();
        }

        // Funcion que permite que la persona no acceda al mismo efecto secundario dos veces por vacunacion
        private bool CheckInList(SideEffect effect)
        {
            return !SideEffects.Exists(item => item.SideEffectId.Equals(effect.Id));
        }

        // Funcion que llena el combobox
        public void InitializeCmbBox()
        {
            // Llenamos la lista de efectos secundarios y la pasamos al comboBox
            Effects = (List<SideEffect>) new SideEffectServices().GetAll().Where(e => CheckInList(e)).ToList();
            cmbEffects.DataSource = Effects;
            cmbEffects.DisplayMember = "Effect";
            cmbEffects.ValueMember = "Id";
        }

        // Funcion que se ejecuta al dar click en agregar efecto
        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica que no esten vacios los minutos
            if (txtMins.Text != string.Empty)
                {
                    // Obtenemos el id del efecto secundario y el efecto en formato de string
                    var sideEffectVm = new SideEffectXAppointmentVm();
                    sideEffectVm.SideEffectId = (int) cmbEffects.SelectedValue;
                    var effectSelectedItem = ((SideEffect) cmbEffects.SelectedItem).Effect;

                    try
                    {
                        // empezamos el try por si el numero es texto
                        sideEffectVm.Lapse = Int32.Parse(txtMins.Text);

                        // Añadimos el nuevo efecto segundario
                        SideEffects.Add(sideEffectVm);

                        // Luego añadimos el efecto y el id para añadirlo en el datagridview
                        SideEffect effect = new SideEffect();
                        effect.Effect = effectSelectedItem;
                        // Lo añadimos a la lista del dgv
                        DgvEffects.Add(effect);

                        // Añadimos los efectos
                        dgvEffects.DataSource = DgvEffects.Select(e => new { Effect = e.Effect } ).ToList();
                    }
                    catch (Exception)
                    {
                        // Si el minuto era una letra muestra lo siguiente:
                        MessageBox.Show("El dato ingresado no es un numero");
                    }
                }
                else
                {
                    // Si el campo de minutos esta vacio muestra el mensaje:
                    MessageBox.Show("El campo de minutos esta vacio, por favor ingrese un minuto");
                }

            // Refrescamos el cmbBox
            InitializeCmbBox();
        }

        // Si se da click en el label se crea un nuevo efecto secundario y llenamos nuevamente el comboBox
        private void AddNewSideEffect_Click(object sender, EventArgs e)
        {
            var newSideEffect = new frmNewSideEffect();
            newSideEffect.ShowDialog();
            InitializeCmbBox();
        }

        // Al clickear en aceptar se cierra el form
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Funcion que deshabilita los controles si se dio click en no hay efectos secundarios
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

        // Si se dio click en que si hay efectos secundarios se habilitan los controles:
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
