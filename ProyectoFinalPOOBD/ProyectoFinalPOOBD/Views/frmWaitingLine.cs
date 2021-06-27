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
    public partial class frmWaitingLine : Form
    {
        public Appointment Appointment { get; set; }
        public Citizen Citizen { get; set; }
        public frmWaitingLine(Appointment appointment, Citizen citizen)
        {
            InitializeComponent();
            Appointment = appointment;
            Citizen = citizen;
            this.dtpDate.MinDate = Appointment.AppointmentDate;
            this.lblDui.Text = Citizen.Dui;
        }

        private void btnWaiting_Click(object sender, EventArgs e)
        {
            Appointment.WaitingDateTime = dtpTime.Value.TimeOfDay;
            var appointmentContext = new AppointmentServices();
            appointmentContext.Update(Appointment);
            MessageBox.Show("Se ha agregado la fecha y hora de espera, se procedera a la vacunacion del ciudadano");
            this.Close();
        }
    }
}
