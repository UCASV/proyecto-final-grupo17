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
            ActivateButton(sender, Color.FromArgb(42, 157, 143));
            tabProgram.SelectTab(2);

        }

        private void btnVaccinationProcess_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(42, 157, 143));
            tabProgram.SelectTab(3);

        }

        private void btnStats_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(42, 157, 143));
            tabProgram.SelectTab(4);
        }

        private void picHome_Click(object sender, System.EventArgs e)
        {
            tabProgram.SelectTab(0);
        }

        private void btnAppointmentProcess_Click_1(object sender, System.EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(42, 157, 143));
            tabProgram.SelectTab(1);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Form formulario = new frmDiseases();
            formulario.Show();
        }

        private void btnAddDisease_Click(object sender, System.EventArgs e)
        {
            Form formulario1 = new frmReservationAppointmentDetails();
            formulario1.Show();
        }
    }
}
 