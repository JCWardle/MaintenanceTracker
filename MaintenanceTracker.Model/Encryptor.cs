using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain
{
    public class Encryptor : IEncryptor
    {
        private const int PASSWORD_SIZE = 50;

        public byte[] GetSalt()
        {
            var salt = new byte[8];
            using(var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(salt);
            }
            return salt;
        }

        public byte[] GetPassword(byte[] salt, string password)
        {
            return new Rfc2898DeriveBytes(password, salt).GetBytes(PASSWORD_SIZE);
        }
    }
}
