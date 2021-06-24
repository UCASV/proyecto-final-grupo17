#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.Repository;
using ProyectoFinalPOOBD.VaccineContext;

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
                    , "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return false;
        }

        // Code for a new Citizen 
        public static bool IfSuccessCitizen(Citizen person, List<Disease> diseases, Institution institution)
        {
            // Si el ciudadano es apto se ingresara el ciudadano y devolvera true
            if (ConditionCitizen(person, diseases, institution))
            {
                person.IdInstitution = institution.Id;
                CitizenServices citizenServices = new CitizenServices();
                citizenServices.Create(person);
                Citizen citizenCreated = citizenServices.GetLastCitizen();

                if (diseases.Count > 0)
                {
                    DiseaseServices.InsertDiseases(diseases, citizenCreated.Id);
                }

                return true;
            }

            return false;
        }

        public static bool ConditionCitizen(Citizen person, List<Disease> diseases, Institution institution)
        {
            // Si la persona es mayor de 60 años
            if (person.Age >= 60)
            {
                return true;
            }

            // Si es mayor de 18 años y tiene enfermedades
            if (person.Age >= 18 && diseases.Count > 0)
            {
                return true;
            }

            // O si pertenece a un equipo del gobierno, salud, educacion o personal de seguridad
            var context = new VaccinationContext();
            var institutions = (new InstitutionServices()).GetInstitutions();
            if (institutions.Exists(i => i.InstitutionName == institution.InstitutionName))
            {
                return true;
            }

            // De lo contrario es falso
            return false;
        }

        // Codigo para generar el pdf en la pagina de detalles de cita reservada

        /*
        private void CreatePdf()
        {
            SaveFileDialog pathDialog = new SaveFileDialog();
            pathDialog.Filter = "PDF document (*.pdf)|*.pdf";
            DialogResult response = pathDialog.ShowDialog();

            if (response == DialogResult.OK)
            {
                path = pathDialog.FileName;
            }

            PdfWriter pdfW = new PdfWriter(pathDialog.FileName);
            PdfDocument pdf = new PdfDocument(pdfW);
            Document document = new Document(pdf, PageSize.LETTER);

            document.SetMargins(60, 20, 55, 20);
            var prueba = new UserServices().Find(1);
            string detalle = "User: " + prueba.Username + Environment.NewLine;
            detalle += "Password: " + prueba.Password;
            Paragraph text = new Paragraph(detalle);
            
            document.Add(text);
            document.Close();
        }
         */

        public static bool CheckIfCitizenExists(Citizen person)
        {
            var people = new CitizenServices().GetCitizenByDui(person.Dui);
            return (people is not null);
        }

        public static bool CreateAppointment(Citizen person, DateTime? time)
        {
            if (CheckIfNotAppointment(person))
            {

                var vaccineAppointment = new AppointmentServices().FillAppointment(person);
                new AppointmentServices().Create(vaccineAppointment);
                return true;
            }
            else
            {
                var allApointments = new AppointmentServices().GetByCitizen(person.Id);
                if (IfPendingVaccination(allApointments[0]).Equals(false))
                {
                    var vaccineAppointment = new AppointmentServices().FillAppointment(person);
                    new AppointmentServices().Create(vaccineAppointment);
                    return true;
                }

                return false;
            }

            return false;
        }

        public static bool CheckIfNotAppointment(Citizen person)
        {
            var listAppointments = new AppointmentServices().GetByCitizen(person.Id);
            return listAppointments.Count == 0;
        }

        public static bool IfPendingVaccination(Appointment appointment)
        {
            return appointment.IdVaccination is null;
        }
    }
}
