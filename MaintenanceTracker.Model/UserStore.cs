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
        IMaintenanceTrackerContext _context;
        IEncryptor _encrpytor;
        public UserStore(IMaintenanceTrackerContext context, IEncryptor encryptor)
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
            user.Salt = salt;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            
            if(user == null)
                return false;
            else
                return user.Password == _encrpytor.GetPassword(user.Salt, password);
        }

        public void ChangePassword(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                throw new ArgumentException("User not found");

            user.Salt = _encrpytor.GetSalt();
            user.Password = _encrpytor.GetPassword(user.Salt, password);

            _context.SaveChanges();
        }

        public void ChangeEmail(string username, string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                throw new ArgumentException("User not found");

            user.Email = email;
            _context.SaveChanges();
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
