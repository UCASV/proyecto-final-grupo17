using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalPOOBD.Backend;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckIfEmpty(txtUserName, txtPassword))
            {
                if (Functions.LoginSuccess(1, txtUserName.Text, txtPassword.Text))
                {
                    this.Hide();
                    var main = new frmMainForm().ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Campos incompletos, por favor llene los datos solicitados para iniciar sesion",
                    "Inicio de sesion: Campos en blanco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CheckIfEmpty(TextBox txt1, TextBox txt2)
        {
            return txt1.Text == string.Empty || txt2.Text == string.Empty;
        }
    }
}
