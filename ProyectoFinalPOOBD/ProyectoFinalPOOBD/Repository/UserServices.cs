using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;


namespace ProyectoFinalPOOBD.Repository
{
    class UserServices: IRepository<Models.User>
    {
        private VaccinationContext _context = new VaccinationContext();

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
        }

        public void Delete(User item)
        {
            _context.Users.Remove(item);
            _context.SaveChanges();
        }

        public User Find(int pk)
        {
            return _context.Users.FirstOrDefault(u => u.Id == pk);
        }

        public User FindByUsernameAndPassword(string username, string password)
        {
            return _context.Users.Include(user => user.Employee).FirstOrDefault(user => user.Username == username && user.Password == password);
        }
    }
}
