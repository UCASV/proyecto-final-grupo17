#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.StyledXmlParser.Jsoup.Nodes;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.Repository;
using ProyectoFinalPOOBD.VaccineContext;
using Document = iText.Layout.Document;
using FontFamily = System.Windows.Media.FontFamily;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;

namespace ProyectoFinalPOOBD.Backend
{
    public static class Utilities
    {
        // Para el login: Sirve para revisar si el usuario existe en la base de datos, si es asi lo registra, de lo contrario no
        public static bool CheckUser(string username, string password)
        {
            User? ifUser = new User();
            ifUser = new UserServices().FindByUsernameAndPassword(username, password);
            return ifUser is not null;
        }

        // Este codigo sirve para ver si existe la cabina segun id ingresado
        public static bool CheckCabin(int id)
        {
            Cabin? ifCabin = new CabinServices().Find(id);
            return (ifCabin is not null);
        }

        // Este codigo es utilizado para validar si se puede iniciar sesion, de ser asi inicia sesion, de lo contrario retorna falso

        public static bool LoginSuccess(int cabinNumber, string username, string password)
        {
            // Revisamos que exista el usuario
            if (CheckUser(username, password))
            {
                // Revisamos si existe la cabina
                if (CheckCabin(cabinNumber))
                {
                    // Obtenemos el empleado
                    Employee employeeLogged = (new UserServices()
                            .FindByUsernameAndPassword(username, password))
                        .Employee;
                    // Obtenemos la cabina
                    Cabin cabinInUse = new CabinServices().Find(cabinNumber);

                    // Creamos el inicio de sesion
                    Login newLogin = new()
                    {
                        LoginDate = DateTime.Now,
                        IdCabin = cabinInUse.Id,
                        IdEmployee = employeeLogged.Id
                    };

                    // Y lo añadimos
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

        // Funcion que retorna verdadero si el ciudadano pudo ser registrado exitosamente
        public static bool IfSuccessCitizen(Citizen person, List<Disease>? diseases, Institution institution)
        {
            // Si el ciudadano es apto se ingresara el ciudadano y devolvera true
            if (ConditionCitizen(person, diseases, institution))
            {
                person.IdInstitution = institution.Id;
                CitizenServices citizenServices = new CitizenServices();

                // Crea al ciudadano
                citizenServices.Create(person);
                Citizen citizenCreated = citizenServices.GetLastCitizen();

                // Si hay enfermedades las agrega a la BD
                if (diseases.Count > 0)
                {
                    DiseaseServices.InsertDiseases(diseases, citizenCreated.Id);
                }

                // Si se completo exitosamente retorna true, sino false
                return true;
            }

            return false;
        }

        // Funcion que verifica que el ciudadano este en una de las condiciones para ser apto
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
        public static void CreatePdf(string place, Citizen person, Appointment appointment)
        {
            // Cremos un SaveDialogFile para obtener la direccion y nombre del archivo a guardar
            SaveFileDialog pathDialog = new SaveFileDialog();
            pathDialog.Filter = "PDF document (*.pdf)|*.pdf";
            DialogResult response = pathDialog.ShowDialog();

            string path = string.Empty;

            // Si se guardo la direccion creamos el pdf con los siguientes datos
            if (response == DialogResult.OK)
            {
                // direccion y nombre del archivo
                path = pathDialog.FileName;

                // Seteamos donde estara y que nombre tiene
                PdfWriter pdfW = new PdfWriter(pathDialog.FileName);
                PdfDocument pdf = new PdfDocument(pdfW);

                // Creamos el documento y le ponemos tamaño carta
                Document document = new Document(pdf, PageSize.LETTER);
                document.SetMargins(60, 50, 55, 50);

                // Añadimos los datos y seteamos su alineacion
                Text header = new Text("------------- VACUNACION COVID 19 -------------").SetTextAlignment(TextAlignment.CENTER);
                header.SetFontSize(20);
                Paragraph pdfText = new Paragraph(header).SetTextAlignment(TextAlignment.CENTER);
                string detalle = "\nCita #" + appointment.IdAppointment + Environment.NewLine;
                detalle += "Nombre del ciudadano: " + person.Name + Environment.NewLine;
                detalle += "DUI del ciudadano: " + person.Dui + Environment.NewLine;
                detalle += "Numero telefonico: " + person.PhoneNumber + Environment.NewLine;
                detalle += "Lugar de vacunacion asignado: " + place + Environment.NewLine;
                detalle += "Fecha de vacunacion: " + appointment.AppointmentDate.Date.ToString("dddd dd MMMM yyyy") + Environment.NewLine;
                detalle += "Hora de vacunacion: " + appointment.AppointmentDate.ToString("hh:mm tt") + Environment.NewLine;
                Text body = new Text(detalle).SetTextAlignment(TextAlignment.JUSTIFIED);
                body.SetFontSize(14);
                pdfText.Add(body);
                pdfText.SetHorizontalAlignment(HorizontalAlignment.CENTER);

                // Añadimos todo al documento y lo guardara donde decidimos guardarlo
                document.Add(pdfText);
                document.Close();
            }
            else
            {
                // Sino le dio a aceptar mostrara el siguiente texto
                MessageBox.Show("Por favor seleccione una direccion para guardar el PDF de la cita");
            }
        }

        // Funcion que verifica si el ciudadano existe segun el dui
        public static bool CheckIfCitizenExists(string dui)
        {
            var people = new CitizenServices().GetCitizenByDui(dui);
            return (people is not null);
        }

        // Funcion utilizada para crear citas
        public static bool CreateAppointment(Citizen person, Employee employeeLogged)
        {
            // Valida si el ciudadano no tiene citas
            if (CheckIfNotAppointment(person))
            {
                // llama a appointment services y llena la cita y por ultimo crea, retorna true si se logro exitosamente
                var vaccineAppointment = new AppointmentServices().FillAppointment(person, employeeLogged, true);
                new AppointmentServices().Create(vaccineAppointment);
                return true;
            }

            // Repite lo mismo anterior solo que este proceso es para segundas citas
            var allAppointments = new AppointmentServices().GetByCitizen(person.Id);
            if (IfPendingVaccination(allAppointments).Equals(true))
            {
                var vaccineAppointment = new AppointmentServices().FillAppointment(person, employeeLogged, false);
                new AppointmentServices().Create(vaccineAppointment);
                return true;
            }

            return false;
        }

        // Revisa si el ciudadano no tiene citas
        public static bool CheckIfNotAppointment(Citizen person)
        {
            var listAppointments = new AppointmentServices().GetByCitizen(person.Id);
            return listAppointments.Count == 0;
        }

        // Revisa si el ciudadano no posee vacunaciones pendientes
        public static bool IfPendingVaccination(List<Appointment> appointment)
        {
            return appointment.First().IdVaccination is not null && appointment.Count == 1;
        }
    }
}
