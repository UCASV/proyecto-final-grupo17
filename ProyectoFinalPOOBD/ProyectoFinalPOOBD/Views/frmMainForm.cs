using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;
using ProyectoFinalPOOBD.Backend;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.Repository;


namespace ProyectoFinalPOOBD.Views
{
    public partial class frmMainForm : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        // Lista de enfermedades del ciudadano
        private List<Disease>? _diseases;
        private Employee employeeLogged;
        private List<Institution> _institutions;

        // Estructura que contiene los colores principales de los botones de seleccion en el formulario principal
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(42, 157, 143);
            public static Color color2 = Color.FromArgb(233, 196, 106);
            public static Color color3 = Color.FromArgb(244, 162, 97);
            public static Color color4 = Color.FromArgb(231, 111, 81);
        }


        public frmMainForm(Employee employeeLogged)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 64);
            pnlMenu.Controls.Add(leftBorderBtn);
            _diseases = new List<Disease>();
            this.employeeLogged = employeeLogged;
            _institutions = new List<Institution>();
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
                DisableButton();
            {
                currentBtn = (IconButton) senderBtn;
                currentBtn.BackColor = Color.FromArgb(51, 95, 112);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(38, 70, 83);
                currentBtn.ForeColor = Color.FloralWhite;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.FloralWhite;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnAppointmentTracking_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            tabProgram.SelectTab(2);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Seguimiento de cita";
        }

        private void btnVaccinationProcess_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            tabProgram.SelectTab(3);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Proceso de vacunacion";
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            tabProgram.SelectTab(4);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Estadisticas";
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            tabProgram.SelectTab(0);
            Reset();
        }

        // Boton de Proceso de cita/ registrar un ciudadano
        private void btnAppointmentProcess_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            tabProgram.SelectTab(1);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Proceso de citas";
            ClearControlsAddCitizen();
            
        }

        // Se encarga de limpiar todos los controles de la pestaña de agregar un nuevo ciudadano
        private void ClearControlsAddCitizen()
        {
            // Obtiene todas las instituciones, y las pasa como DataSource al datagridview
            _institutions = new InstitutionServices().GetAllInstitutions();
            cmbInstitucion.DataSource = _institutions.Select(i => i.InstitutionName).ToList();
            cmbInstitucion.SelectedIndex = cmbInstitucion.Items.IndexOf("Ninguna");

            // Deja los textbox, numeric up down y las enfermedades limpias sin ningun dati
            txtDui.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            nudAge.Value = 0;
            _diseases = null;
            _diseases = new List<Disease>();

        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            lblTitle.Text = "Home";
            icoTitle.IconChar = IconChar.Home;
        }

        // Abre el formulario de añadir enfermedad al darle click
        private void btnAddDisease_Click(object sender, EventArgs e)
        {
            using (var diseasesForm = new frmDiseases(_diseases))
            {
                diseasesForm.ShowDialog();
                // Obtenemos las enfermedades retornadas por dicho formulario
                _diseases = diseasesForm.ReturnList;
            }
        }

        private void pnlTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDuiSearch_Click(object sender, EventArgs e)
        {
            // Prueba para abrir formulario de espera de cita
            Form formulario2 = new frmNewSideEffect();
            formulario2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVaccineStart_Click(object sender, EventArgs e)
        {
            var secondaryEffects = new frmSideEffects();
            secondaryEffects.Show();
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Este evento sucede cuando el gestor selecciona uno de los radiobutton
        private void rdoYes_CheckedChanged(object sender, EventArgs e)
        {
            // Si el radiobutton seleccionado es no, inhabilita el boton de enfermedades o discapacidades
            if (rdoNo.Checked)
            {
                btnAddDisease.Enabled = false;
                // Por si el usuario se equivoca que no tiene enfermedades, se bloquea el boton y se limpia la lista
                _diseases = new List<Disease>();
            }

            // De lo contrario lo habilita para que se pueda agregar una lista de enfermedades o discapacidades
            if (rdoYes.Checked)
            {
                btnAddDisease.Enabled = true;
            }
        }
        
        // Es una funcion que retorna que los datos necesarios y/o principales esten llenos
        private bool FilledForm() => txtDui.Text != String.Empty && txtName.Text != String.Empty && txtAddress.Text != String.Empty && nudAge.Value > 0 && txtPhoneNumber.Text != String.Empty;

        // Funcion que registra al ciudadano
        private void AddApointment_Click(object sender, EventArgs e)
        {
            if (FilledForm())
            {
                if (!Functions.CheckIfCitizenExists(txtDui.Text))
                {
                    var newCitizen = new Citizen()
                    {
                        Name = txtName.Text,
                        Dui = txtDui.Text,
                        Mail = txtEmail.Text ?? "Sin correo electronico",
                        Age = (int) nudAge.Value,
                        Address = txtAddress.Text,
                        PhoneNumber = txtPhoneNumber.Text
                    };

                    var institutionPk = cmbInstitucion.SelectedIndex + 1;
                    var selectedInstitution = new InstitutionServices().Find(institutionPk);

                    if (Functions.IfSuccessCitizen(newCitizen, _diseases, selectedInstitution))
                    {
                        MessageBox.Show("El ciudadano pertenece al grupo de atencion, ha sido registrado exitosamente",
                            "Ciudadano registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                    }
                    else
                    {
                        MessageBox.Show(
                            "El ciudadano ingresado no pertenece al grupo de atencion, aun no es apto para vacunacion",
                            "Ciudadano no registrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                    }
                    ClearControlsAddCitizen();
                    tabProgram.SelectedIndex = 3;
                }
                else
                {
                    MessageBox.Show(
                        "No puede ingresarse al actual ciudadano, este ya esta en la lista de ciudadanos registrados",
                        "Registrar ciudadano: Ciudadano previamente registrado", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Datos incompletos, por favor llene todos los datos del ciudadano",
                    "Añadir ciudadano: Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
 