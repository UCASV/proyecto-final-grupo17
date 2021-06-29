using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.Backend;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.Repository;
using ProyectoFinalPOOBD.VaccineContext;
using ProyectoFinalPOOBD.ViewModel;


namespace ProyectoFinalPOOBD.Views
{
    public partial class frmMainForm : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        // Lista de enfermedades del ciudadano
        private List<Disease>? _diseases;

        // Variable que guardara el empleado que inicio sesion
        private Employee _employeeLogged;

        // Variable que guardar las instituciones
        private List<Institution> _institutions;

        // Variable que guardara cita y vacunacion si se encuentra al ciudadano
        private Appointment _currentVaccination;
        private Citizen _currenCitizen;
        

        // Estructura que contiene los colores principales de los botones de seleccion en el formulario principal
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(42, 157, 143);
            public static Color color2 = Color.FromArgb(233, 196, 106);
            public static Color color3 = Color.FromArgb(244, 162, 97);
            public static Color color4 = Color.FromArgb(231, 111, 81);
        }


        // Inicializamos el formulario principal
        public frmMainForm(Employee employeeLogged)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 64);
            pnlMenu.Controls.Add(leftBorderBtn);
            _diseases = new List<Disease>();
            this._employeeLogged = employeeLogged;
            _institutions = new List<Institution>();
            _currentVaccination = new Appointment();
            _currenCitizen = new Citizen();
        }

        // Funcion que sirve para cambiar el color del boton, icono y nombre de la pestaña
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

        // Funcion para desahibilitar el boton actual
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

        // Boton para buscar las citas mediante el DUI del ciudadano
        private void btnAppointmentTracking_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            tabProgram.SelectTab(2);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Seguimiento de cita";
        }

        // Boton del proceso de vacunacion
        private void btnVaccinationProcess_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Primero debe ingresar el DUI del usuario en el apartado seguimiento de cita");
        }

        // Boton para ver las estadisticas
        private void btnStats_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            tabProgram.SelectTab(4);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Estadisticas";
            FillStats();
        }

        // Funcion que redirecciona a home al presionar click en el icono
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
        

        // Se encarga de reiniciar los botones y volver a home
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            lblTitle.Text = "Home";
            icoTitle.IconChar = IconChar.Home;
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        // Funciones para añadir un ciudadano

        // Funcion que limpia los controles para registrar un ciudadano
        private void ClearControlsAddCitizen()
        {
            // Obtiene todas las instituciones, y las pasa como DataSource al comboBox
            _institutions = new InstitutionServices().GetAllInstitutions();
            cmbInstitucion.DataSource = _institutions.Select(i => i.InstitutionName).ToList();

            // Selecciona por defecto ninguna en el combobox
            cmbInstitucion.SelectedIndex = cmbInstitucion.Items.IndexOf("Ninguna");

            // Deja los textbox, numeric up down y las enfermedades limpias sin ningun dati
            txtDui.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            nudAge.Value = 0;
            

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

        private bool ValidDui(string dui)
        {
            Regex regex = new Regex("^\\d{8}-\\d$");
            if (dui.Length == 10 || regex.IsMatch(dui))
            {
                return true;
            }
            else
            {
                MessageBox.Show("El valor del DUI esta en un formato invalido");
                return false;
            }

        }

        private bool ValidNumber(string phoneNumber)
        {
            Regex regex = new Regex("^\\d{4}-\\d{4}$");
            if (phoneNumber.Length == 9 && regex.IsMatch(phoneNumber))
            {
                return true;
            }
            else
            {
                MessageBox.Show("El formato del numero de telefono es invalido, por favor ingrese uno valido");
                return false;
            }
        }

        // Funcion que registra al ciudadano
        private void AddApointment_Click(object sender, EventArgs e)
        {
            // Se valida si el formulario existe
            if (FilledForm())
            {
                if (ValidDui(txtDui.Text) && ValidNumber(txtPhoneNumber.Text))
                {
                    // Si el ciudadano no existe verificando con su dui, se procede a registrarlo
                    if (!Utilities.CheckIfCitizenExists(txtDui.Text))
                    {
                        var mail = txtEmail.Text != string.Empty ? txtEmail.Text : "Sin correo electronico";

                        // Llenamos los datos del ciudadano con los datos del form
                        var newCitizen = new Citizen()
                        {
                            Name = txtName.Text,
                            Dui = txtDui.Text,
                            Mail = mail,
                            Age = (int)nudAge.Value,
                            Address = txtAddress.Text,
                            PhoneNumber = txtPhoneNumber.Text
                        };

                        // Obtenemos el indice la institucion ingresada
                        var institutionPk = cmbInstitucion.SelectedIndex + 1;

                        // Se busca la institucion por el Id
                        var selectedInstitution = new InstitutionServices().Find(institutionPk);

                        // Luego va a una funcion que registrara al ciudadano, si retorna true es porque se registro exitosamente

                        if (Utilities.IfSuccessCitizen(newCitizen, _diseases, selectedInstitution))
                        {
                            MessageBox.Show("El ciudadano pertenece al grupo de atencion, ha sido registrado exitosamente",
                                "Ciudadano registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            var context = new VaccinationContext();

                            // Obtenemos el ciudadano recien creado
                            var citizenCreated = new CitizenServices().GetCitizenByDui(newCitizen.Dui);

                            // Y procedemos a crear la cita, si retorna true la cita se registro exitosamente
                            if (Utilities.CreateAppointment(citizenCreated, _employeeLogged))
                            {
                                // Al haberse creado la cita buscamos la cita reciente registrada al ciudadano
                                var lastAppointment = new AppointmentServices().GetLastByCitizen(citizenCreated.Id);

                                // Y se abre el formulario donde dara los detalles e informacion del PDF
                                var details = new frmReservationAppointmentDetails(lastAppointment, citizenCreated);
                                details.ShowDialog();
                                _diseases = null;
                                _diseases = new List<Disease>();
                            }
                        }
                        else
                        {
                            // Si no se pudo crear al ciudadano por los requisitos se ejecuta el siguiente codigo
                            MessageBox.Show(
                                "El ciudadano ingresado no pertenece al grupo de atencion, aun no es apto para vacunacion",
                                "Ciudadano no registrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }

                        // Se cambiara a la pestaña de seguimiento de citas
                        tabProgram.SelectedIndex = 2;
                        ActivateButton(btnAppointmentTracking, RGBColors.color2);
                        icoTitle.IconChar = currentBtn.IconChar;
                        lblTitle.Text = "Proceso de citas";

                        // Limpiamos los controles
                        ClearControlsAddCitizen();
                    }
                    else
                    {
                        // Este codigo se ejecuta si el ciudadano existe, se verificara si no posee citas
                        MessageBox.Show(
                            "No puede ingresarse al actual ciudadano, este ya esta en la lista de ciudadanos registrados",
                            "Registrar ciudadano: Ciudadano previamente registrado", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        MessageBox.Show("Verificaremos si el ciudadano tiene cita para su primera dosis",
                            "Citas: Primera dosis", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Obtenemos al ciudadano por su DUI y vereficamos si tiene citas, y de no tener creamos la cita
                        var citizen = new CitizenServices().GetCitizenByDui(txtDui.Text);

                        // Mediante esta funcion:
                        RegisteredCitizenAppointment(citizen);
                    }
                }
            }
            else
            {
                // Este codigo se ejecuta si los datos estan incompletos
                MessageBox.Show("Datos incompletos, por favor llene todos los datos del ciudadano",
                    "Añadir ciudadano: Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RegisteredCitizenAppointment(Citizen person)
        {
            // Se verifica si el ciudadano tiene citas o vacunas, si es posible agendar entonces creara la cita y devolvera true
            if (Utilities.CreateAppointment(person, _employeeLogged))
            {
                // Obtenemos la cita recien creada del ciudadano
                var lastAppointment = new AppointmentServices().GetLastByCitizen(person.Id);

                // La pasamos como parametro al formulario para detalles, luego se mostrara el detalle y generara el pdf
                var details = new frmReservationAppointmentDetails(lastAppointment, person);

                MessageBox.Show("El ciudadano aun no poseia citas, se generara la cita a continuacion",
                    "Ciudadano registrado: Cita generada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                details.ShowDialog();
            }
            else
            {
                // Si devolvio false, es porque el ciudadano ya tiene las vacunaciones o citas pendientes
                MessageBox.Show("El ciudadano ya recibio las vacunas o posee citas pendientes");
            }
        }

        // Funciones de seguimiento de citas

        // Funcion al darle click a buscar, buscara si hay un ciudadano con citas pendientes o si existe
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Ponemos la variable que contendra al ciudadano si existe como nulo 

            _currenCitizen = null;

            // Verificamos que el textbox del DUI no este vacio
            if (txtDuiData.Text != String.Empty)
            {
                // Llamamos al context
                var context = new VaccinationContext();

                // obtenemos al ciudadano si existe, pasando a CitizenServices el dui del ciudadano
                var ifCitizen = new CitizenServices().GetCitizenByDui(txtDuiData.Text);

                // Si la variable no es nula, es decir si el ciudadano existe se ejecuta el siguiente if
                if (ifCitizen is not null)
                {
                    // Obtenemos al ciudadano del DUI ingresado, ahora lo volvemos a buscar pero ademas de que su DUI sea igual
                    // Debe cumplir que tenga una cita pero la vacunacion aun es nula, o si no si tiene dos citas y
                    // la ultima vacunacion es nula, es decir si es la segunda vacuna es la vacunacion actual

                    var citizen = context.Citizens.Include(c => c.Appointments)
                        .FirstOrDefault(c => c.Dui == txtDuiData.Text &&
                                             ((c.Appointments.Count == 1 && c.Appointments.First().IdVaccination == null) || 
                                              (c.Appointments.Count == 2 && c.Appointments.OrderBy(a => a.IdAppointment).Last().IdVaccination == null)));
                    
                    // Si se cumplieron las condiciones el ciudadano tiene una de esas citas, si no es nulo pasamos al siguiente if
                    if (citizen is not null)
                    {
                        // Traemos la primera cita del ciudadano que tenga el id de vacunacion sea nulo y que el dui sea igual al del ciudadano
                        var appointment = context.Appointments.Include(a => a.IdCitizenNavigation)
                            .Include(a => a.IdPlaceNavigation)
                            .FirstOrDefault(a => a.IdCitizenNavigation.Dui == txtDuiData.Text && a.IdVaccination == null);

                        // Configuramos el ciudadano actual y la cita
                        _currentVaccination = appointment;
                        _currenCitizen = ifCitizen;

                        // Llenamos el listbox
                        FillList(_currentVaccination, _currenCitizen);
                        // Habilitamos la espera
                        btnWaiting.Enabled = true;
                    }
                    else
                    {
                        // El ciudadano existe pero ya recibio sus vacunas
                        MessageBox.Show("El ciudadano ingresado no posee citas pendientes.");
                        // Se limpia el listbox
                        lstMain.Items.Clear();
                        // Se añade al listbox
                        lstMain.Items.Add("Sin resultados de citas del ciudadano");
                        
                        btnWaiting.Enabled = false;
                    }
                }
                else
                {
                    // Si el ciudadano no existe entonces se muestra el siguiente bloque
                    MessageBox.Show(
                        "El DUI ingresado no esta asignado a ningun ciudadano, puede ingresarlo desde proceso de cita");

                    // Limpiamos el listbox
                    lstMain.Items.Clear();
                    // Y ponemos el texto en el listbox
                    lstMain.Items.Add("Sin resultados");
                    btnWaiting.Enabled = false;
                }
            }
            else
            {
                // Si no se ha llenado el textbox se muestra lo siguiente:
                MessageBox.Show("El campo de DUI esta vacio, por favor ingrese uno para comenzar la busqueda");
                btnWaiting.Enabled = false;
            }
        }

        // La funcion clear limpia los datos del textbox para el DUI
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDuiData.Text = String.Empty;
            txtDuiData.PlaceholderText = "Ingrese el numero de DUI de un ciudadano";
        }

        // Esta funcion llena el listbox cuando hay una cita y ciudadano encontrados:
        private void FillList(Appointment appointment, Citizen citizen)
        {
            // Llenamos el listbox
            lstMain.Items.Clear();
            string lstText = "<<<<<<<<<<< Datos del ciudadano >>>>>>>>>>>" + Environment.NewLine;
            // Con add agregamos el texto a la listbox
            lstMain.Items.Add(lstText);
            lstText = "Nombre del ciudadano: " + citizen.Name + Environment.NewLine;
            lstMain.Items.Add(lstText);
            lstText = "DUI del ciudadano: " + citizen.Dui + Environment.NewLine;
            lstMain.Items.Add(lstText);
            lstText = "Edad del ciudadano: " + citizen.Age + Environment.NewLine;
            lstMain.Items.Add(lstText);
            lstText = "<<<<<<<<<<< Datos de la cita >>>>>>>>>>>" + Environment.NewLine;
            lstMain.Items.Add(lstText);
            lstText = "Numero de cita: " + appointment.IdAppointment.ToString() + Environment.NewLine;
            lstMain.Items.Add(lstText);
            // Formateamos la fecha y hora de la cita para pasarla a la listbox
            lstText = "Fecha de cita: " + appointment.AppointmentDate.ToString("dddd dd MMMM yyyy") + Environment.NewLine;
            lstMain.Items.Add(lstText);
            lstText = "Hora de la cita: " + appointment.AppointmentDate.ToString("hh:mm tt") + Environment.NewLine;
            lstMain.Items.Add(lstText);
            lstText = "Lugar de vacunacion: " + appointment.IdPlaceNavigation.PlaceName + Environment.NewLine;
            lstMain.Items.Add(lstText);

        }

        // Al darle click al boton de proceder a espera se ejecuta el siguiente codigo:
        private void btnWaiting_Click(object sender, EventArgs e)
        {
            // Se le pide el consentimiento al ciudadano:
            DialogResult result = MessageBox.Show("El ciudadano actual posee cita para realizar la vacunacion, desea proseguir?",
                "Seguimiento de citas: Vacunacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el ciudadano acepta se procede al proceso de espera
            if (result == DialogResult.Yes)
            {
                // Se limpia el textbox de seguimiento de citas
                txtDuiData.Text = String.Empty;

                // Se abre el formulario para registrar la fecha y hora de espera, pasando la cita/vacunacion y el ciudadano
                using (var waitingForm = new frmWaitingLine(_currentVaccination, _currenCitizen))
                {
                    // Se muestra la ventana
                    waitingForm.ShowDialog();
                    // Ya que se modifica la hora de espera igualamos la cita/vacunacion del form principal con el form de fila de espera
                    _currentVaccination = waitingForm.Appointment;

                    // Pasamos al formulario de iniciar el proceso de vacunacion para ingresar la fecha y la hora que se va a aplicar la vacuna
                    ActivateButton(btnVaccinationProcess, RGBColors.color3);
                    icoTitle.IconChar = currentBtn.IconChar;
                    lblTitle.Text = "Proceso de vacunacion";

                    // Nos movemos a la pestaña de vacunacion
                    tabProgram.SelectedIndex = 3;
                }

                lstMain.Items.Clear();

                // Seteamos la fecha minima en el datetimepicker de vacunacion como la fecha de la cita
                dtpVaccinationDate.MinDate = _currentVaccination.AppointmentDate;
            }
        }

        // Funcion que se ejecuta al darle click al boton empezar vacunacion
        private void btnVaccineStart_Click(object sender, EventArgs e)
        {
            // Llamamos a appointment services
            var appointmentContext = new AppointmentServices();
            
            // Obtenemos el ultimo id de vacunacion y le sumamos 1 para el nuevo id 
            _currentVaccination.IdVaccination = appointmentContext.GetLastIdVaccination() + 1;

            // Obtenemos la fecha y hora desde el datetimepicker y la añadimos a la fecha y hora de vacunacion
            _currentVaccination.VaccineDateTime = dtpVaccinationDate.Value.Date + dtpHours.Value.TimeOfDay;

            // Actualizamos los datos obtenidos en la base de datos
            appointmentContext.Update(_currentVaccination);

            // Esta lista contiene el id de los efectos secundarios y el efecto para agregarlo a los efectos presentados
            // Por la vacunacion
            var effectsId = new List<ViewModel.SideEffectXAppointmentVm>();

            MessageBox.Show("Vacunando al ciudadano...");
            MessageBox.Show("Ciudadano vacunado exitosamente!");

            // Abrimos el formulario de efectos secundarios
            using (var secondaryEffects = new frmSideEffects())
            {
                secondaryEffects.ShowDialog();
                // Obtenemos la lista de efectos secundarios resultantes en el formulario sideeffects
                effectsId = secondaryEffects.SideEffects;
            }

            // Si hubo un efecto secundario lo agregamos a continuacion
            if (effectsId.Count > 0)
            {
                // effectsServices nos permitira añadir los efectos presentados luego de la vacunacion
                var effectsServices= new AppointmentXSideEffectsServices();

                // effectXappointment es una variable que nos ayudara a agregar los efectos secundarios:

                SideEffectXappointment effectXappointment = new SideEffectXappointment();

                // Hacemos un foreach a los efectos secundarios, para añadirlos uno a uno a la base de datos
                effectsId.ForEach(e =>
                {
                    effectXappointment.IdAppointment = _currentVaccination.IdAppointment;
                    effectXappointment.IdSideEffect = e.SideEffectId;
                    effectXappointment.Lapse = e.Lapse;
                    effectsServices.Create(effectXappointment);
                });
                MessageBox.Show("Los efectos secundarios han sido añadidos a la revision de la vacunacion");
            }

            // Se pasa el ciudadano y el gestor, si se pudo crear una segunda cita para la ultima dosis devolvera true
            if (Utilities.CreateAppointment(_currenCitizen, _employeeLogged))
            {
                MessageBox.Show("Se le ha asignado una nueva cita para la segunda dosis de vacunacion",
                    "Asignacion de segunda dosis", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Obtenemos la ultima cita
                var lastApointment = new AppointmentServices().GetLastByCitizen(_currenCitizen.Id);

                // Pasamos la cita y el ciudadano como parametros para mostrar los detalles:
                var frmDetails = new frmReservationAppointmentDetails(lastApointment, _currenCitizen);
                frmDetails.ShowDialog();
            }
            else
            {
                // Sino, ya se termina el proceso de vacunacion para este ciudadano.
                MessageBox.Show("Se le han brindado ambas dosis de la vacuna al ciudadano",
                    "Finalizacion de vacunaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Nos movemos de pestaña para seguimiento de citas:
            ActivateButton(btnAppointmentTracking, RGBColors.color2);
            tabProgram.SelectTab(2);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Seguimiento de cita";

            _currenCitizen = null;
            _currentVaccination = null;
            btnWaiting.Enabled = false;
        }

        

        // Code for stats

        // Funcion para llenar las estadisticas:
        // Debido a que hay incompatibilidad con los graficos estos datos se muestran en labels
        public void FillStats()
        {
            // primera dosis
            lblDose1.Text = Queries.OneVaccination().ToString();

            // Segunda dosis
            lblDose2.Text = Queries.TwoVaccination().ToString();

            var efficiencyStats = Queries.EfficiencyVaccination();

            // Eficiencia en vacunacion:
            lbl15Min.Text = efficiencyStats[0].ToString();
            lbl30Min.Text = efficiencyStats[1].ToString();
            lbl1Hour.Text = efficiencyStats[2].ToString();
            lbl1HourPlus.Text = efficiencyStats[3].ToString();
        }
    }
}
 