using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccountManager : IDisposable
    {
        MaintenanceTrackerEntities _context;

        public AccountManager()
        {
            _context = new MaintenanceTrackerEntities();
        }

        public void CreateUser(string username, string password, string email)
        {
            //Validation etc...
            _context.Users.Add(new User
            {
                Username = username,
                Password = password,
                Email = email
            });
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
