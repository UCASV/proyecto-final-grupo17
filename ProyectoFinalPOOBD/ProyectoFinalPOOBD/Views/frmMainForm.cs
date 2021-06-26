using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FontAwesome.Sharp;


namespace ProyectoFinalPOOBD.Views
{
    public partial class frmMainForm : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(42, 157, 143);
            public static Color color2 = Color.FromArgb(233, 196, 106);
            public static Color color3 = Color.FromArgb(244, 162, 97);
            public static Color color4 = Color.FromArgb(231, 111, 81);
        }


        public frmMainForm()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 64);
            pnlMenu.Controls.Add(leftBorderBtn);
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

        private void btnAppointmentTracking_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            tabProgram.SelectTab(2);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Seguimiento de cita";
        }

        private void btnVaccinationProcess_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            tabProgram.SelectTab(3);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Proceso de vacunacion";
        }

        private void btnStats_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            tabProgram.SelectTab(4);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Estadisticas";
        }

        private void picHome_Click(object sender, System.EventArgs e)
        {
            tabProgram.SelectTab(0);
            Reset();
        }

        private void btnAppointmentProcess_Click_1(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            tabProgram.SelectTab(1);
            icoTitle.IconChar = currentBtn.IconChar;
            lblTitle.Text = "Proceso de citas";
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            lblTitle.Text = "Home";
            icoTitle.IconChar = IconChar.Home;
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            Form addAppointmentDetails = new frmReservationAppointmentDetails();
            addAppointmentDetails.Show();
        }

        private void btnAddDisease_Click(object sender, System.EventArgs e)
        {
            Form formulario = new frmDiseases();
            formulario.Show();
        }

        private void pnlTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDuiSearch_Click(object sender, System.EventArgs e)
        {
            // Prueba para abrir formulario de espera de cita
            Form formulario2 = new frmNewSideEffect();
            formulario2.Show();
        }

        private void label3_Click(object sender, System.EventArgs e)
        {

        }

        private void btnVaccineStart_Click(object sender, System.EventArgs e)
        {
            Form secondaryEffects = new frmSideEffects();
            secondaryEffects.Show();
        }
    }
}
 