using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    // CRUD de la clase Employee mas operaciones extras
    class EmployeeServices : IRepository<Employee>
    {
        private VaccinationContext _context = new VaccinationContext();

        public List<Employee> GetAll()
        {
            var employees = _context.Employees.Include(e => e.IdUserNavigation)
                .Include(e => e.IdEmployeeTypeNavigation)
                .Include(e => e.IdCabinNavigation).ToList();

            return employees;
        }

        public void Create(Employee item)
        {
            _context.Employees.Add(item);
            _context.SaveChanges();
        }

        public void Update(Employee item)
        {
            _context.Employees.Update(item);
            _context.SaveChanges();
        }

        public void Delete(Employee item)
        {
            _context.Employees.Remove(item);
            _context.SaveChanges();
        }

        public Employee Find(int pk)
        {
            var employee = _context.Employees
                .Include(e => e.IdUserNavigation)
                .Include(e => e.IdCabinNavigation)
                .Include(e => e.IdEmployeeTypeNavigation)
                .FirstOrDefault(e => e.Id == pk);

            return employee;
        }

        // Funcion para encontrar el gestor
        public Employee FindGestor(string username, string password)
        {
            var employee = _context.Employees.Include(e => e.IdUserNavigation).SingleOrDefault(e =>
                e.IdUserNavigation.Username == username && e.IdUserNavigation.Password == password);

            return employee;
        }
    }
}
