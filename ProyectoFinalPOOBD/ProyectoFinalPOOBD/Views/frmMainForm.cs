using System.Windows.Forms;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
            var em = new Employee();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            EmployeeType typeEmp = new EmployeeType();
            typeEmp.Type = "Doctor General";

            var db = new VaccinationContext();
            db.EmployeeTypes.Add(typeEmp);
            db.SaveChanges();

            Employee emp = new Employee();
            emp.Address = "San Salvador";
            emp.Name = "Carlos";
            emp.Mail = "carlos@gmail.com";
            emp.IdEmployeeTypeNavigation = typeEmp;
            db.Employees.Add(emp);
            db.SaveChanges();
        }
    }
}
