using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccountManager : IDisposable
    {
        private const int SALT_SIZE = 6;
        MaintenanceTrackerEntities _context;

        public AccountManager()
        {
            _context = new MaintenanceTrackerEntities();
        }

        public void CreateUser(string username, string password, string email)
        {
            //TODO: encrypt salt
            var salt = GetNewSalt();

            if (_context.Users.Any(u => u.Username == username))
                throw new InvalidOperationException("That username is already taken");

            _context.Users.Add(new User
            {
                Username = username,
                Password = GetHash(password),
                Email = email,
                Salt = salt
            });
            _context.SaveChanges();
        }

        private string GetHash(string password)
        {
            using (var hash = MD5.Create())
            {
                var data = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();

                for (var i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public string GetNewSalt(){
            var rand = new Random();
            var result = new StringBuilder(); 

            for(int i = 0; i < SALT_SIZE; i++)
                result.Append(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));

            return result.ToString();
        }        

        public bool Login(string username, string password)
        {
            var user = _context.Users.First(u => u.Username == username);

            return GetHash(password) == user.Password;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
