using MaintenanceTracker.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Tests.Domain
{
    [TestFixture]
    public class Encrypter_Tests
    {
        [Test]
        public void Salt_Eight_Bytes_Long()
        {
            var encryptor = new Encryptor();

            var result = encryptor.GetSalt();

            Assert.AreEqual(8, result.Length);
        }

        [Test]
        public void Encrypt_Password()
        {
            var password = "test";
            var salt = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var encryptor = new Encryptor();

            var result = encryptor.GetPassword(salt, password);

            Assert.AreEqual(50, result.Length);
        }
    }
}
