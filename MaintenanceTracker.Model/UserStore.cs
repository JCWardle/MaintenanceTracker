using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain
{
    public class UserStore : IUserStore, IDisposable
    {
        MaintenanceTrackerContext _context;
        IEncryptor _encrpytor;
        public UserStore(MaintenanceTrackerContext context, IEncryptor encryptor)
        {
            _context = context;
            _encrpytor = encryptor;
        }

        public void AddUser(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username required");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password required");
            if(_context.Users.Any(u => u.Username == user.Username))
                throw new ArgumentException("Username already taken");

            var salt = _encrpytor.GetSalt();
            user.Password = _encrpytor.GetPassword(salt, password);

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void ChangePassword(int id, string password)
        {
            throw new NotImplementedException();
        }

        public void ChangeEmail(int id, string email)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
