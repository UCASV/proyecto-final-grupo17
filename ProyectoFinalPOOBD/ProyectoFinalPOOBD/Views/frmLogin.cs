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
            try
            {
                var value = GetNumber(txtCabin);

                if (!CheckIfEmpty(txtUserName, txtPassword, txtCabin))
                {
                    if (Functions.LoginSuccess(value, txtUserName.Text, txtPassword.Text))
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
            catch (Exception)
            {
                MessageBox.Show("Por favor ingrese un numero de cabina y no un caracter.",
                    "Inicio de sesion: datos erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckIfEmpty(TextBox txt1, TextBox txt2, TextBox txt3)
        {
            return txt1.Text == string.Empty || txt2.Text == string.Empty || txt3.Text == string.Empty;
        }

        private int GetNumber(TextBox txt)
        {
            int value;
            value = Int32.Parse(txt.Text);
            return value;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
