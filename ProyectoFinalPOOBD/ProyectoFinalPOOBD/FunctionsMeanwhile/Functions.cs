#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.Repository;
using ProyectoFinalPOOBD.VaccineContext;
using ProyectoFinalPOOBD.Views;

namespace ProyectoFinalPOOBD.FunctionsMeanwhile
{
    public static class Functions
    {
        // Para el login: Sirve para revisar si el usuario existe en la base de datos, si es asi lo registra, de lo contrario no
        public static bool CheckUser(string username, string password)
        {
            User? ifUser = new UserServices().FindByUsernameAndPassword(username, password);
            return (ifUser is not null);
        }

        // This code is for login
        public static bool CheckCabin(int id)
        {
            Cabin? ifCabin = new CabinServices().Find(id);
            return (ifCabin is not null);
        }

        // This code goes for all the login:

        public static bool LoginSuccess(int cabinNumber, string username, string password)
        {
            if (CheckUser(username, password))
            {
                if (CheckCabin(cabinNumber))
                {
                    Employee employeeLogged = (new UserServices()
                        .FindByUsernameAndPassword(username, password))
                        .Employee;

                    Cabin cabinInUse = new CabinServices().Find(cabinNumber);

                    Login newLogin = new()
                    {
                        LoginDate = DateTime.Now,
                        IdCabin = cabinInUse.Id,
                        IdEmployee = employeeLogged.Id
                    };
                    
                    var context = new VaccinationContext();
                    context.Logins.Add(newLogin);
                    context.SaveChanges();

                    return true;
                }

                MessageBox.Show("No se encontro la cabina ingresada, ingrese el numero de una cabina existente."
                    , "Cabina no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No se encontro al usuario, por favor revise el usuario y la contraseña"
                    ,"Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return false;
        }
    }
}
