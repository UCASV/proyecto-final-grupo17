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
using ProyectoFinalPOOBD.Repository;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // Boton que limpia los textBox
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtCabin.Text = string.Empty;
        }
        
        // Al darle click a login se intentara realizar la verificacion de existencia de cabina y usuario
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Revisamos que los valores no esten nulos
            if (!CheckIfEmpty(txtUserName, txtPassword, txtCabin))
            {
                try
                {
                    // Obtenemos el numero de la cabina
                    var value = GetNumber(txtCabin);

                    // Se busca al usuario y la cabina, y si existen se valida y automaticamente se registra el login
                    if (Utilities.LoginSuccess(value, txtUserName.Text, txtPassword.Text))
                    {
                        
                        

                        // Abrimos el form principal y buscamos al empleado (gestor) segun usuario y contraseña
                        var employeeLogged = new EmployeeServices().FindGestor(txtUserName.Text, txtPassword.Text);
                        
                        // Mostramos un mensaje de exito
                        MessageBox.Show($"Bienvenido {employeeLogged.Name}", "Inicio de sesion exitoso",
                            MessageBoxButtons.OK);

                        this.Hide();

                        // Pasamos a main
                        var main = new frmMainForm(employeeLogged).ShowDialog();
                        
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(
                        "El valor ingresado en cabina no es un numero, por favor ingrese un numero correcto",
                        "Inicio sesion: Valores invalidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                    // Se mostrata si hay datos incompletos
                    MessageBox.Show("Campos incompletos, por favor llene los datos solicitados para iniciar sesion",
                        "Inicio de sesion: Campos en blanco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    

        // Se revisa que los textbox no esten vacios
        private bool CheckIfEmpty(TextBox txt1, TextBox txt2, TextBox txt3)
        {
            return txt1.Text == string.Empty || txt2.Text == string.Empty || txt3.Text == string.Empty;
        }

        // recogemos el valor del textbox
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
