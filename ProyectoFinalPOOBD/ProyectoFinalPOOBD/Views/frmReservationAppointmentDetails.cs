using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using ProyectoFinalPOOBD.Backend;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.Repository;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmReservationAppointmentDetails : Form
    {
        private Appointment _appointmentDetails;
        private Citizen _citizen;

        // Inicializamos el formulario
        public frmReservationAppointmentDetails(Appointment appointment, Citizen citizen)
        {
            InitializeComponent();
            _appointmentDetails = appointment;
            _citizen = citizen;
        }

        // Esta funcion carga los datos que se mostraran en el form que muestra los detalles:
        private void frmReservationAppointmentDetails_Load(object sender, EventArgs e)
        {
            lblDuiData.Text = _citizen.Dui;
            lblPlaceData.Text = ((new PlaceServices()).GetById(_appointmentDetails.IdPlace)).PlaceName;
            lblDateData.Text = _appointmentDetails.AppointmentDate.Date.ToString("dddd dd MMMM yyyy");
            lblHourData.Text = _appointmentDetails.AppointmentDate.ToString("hh:mm tt");

        }

        // Añ darñe click a generar, si se genero el pdf se mostrara el siguiente mensaje y se cierra el form
        private void btnGereratePdf_Click(object sender, EventArgs e)
        {
            Utilities.CreatePdf(lblPlaceData.Text, _citizen, _appointmentDetails);
            this.Close();
        }
    }
}
