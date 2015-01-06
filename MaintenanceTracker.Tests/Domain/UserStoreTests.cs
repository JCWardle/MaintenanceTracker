using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;
using MaintenanceTracker.Tests.Domain.Context;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Linq;

namespace MaintenanceTracker.Tests.Domain
{
    [TestFixture]
    public class UserStoreTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Username already taken")]
        public void Add_Duplicate_Username()
        {
            var context = new MockContext();
            context.Users.Add(
                new User { Username= "test"}
            );            
            var encryptor = new Mock<IEncryptor>();            
            var userStore = new UserStore(context, encryptor.Object);

            userStore.AddUser(new User { Username = "test" }, "password");
        }

        [Test]
        public void Password_Gets_Encrypted()
        {
            var salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var password = new byte[] { 5, 6, 7, 8 };
            var encryptor = new Mock<IEncryptor>();
            var context = new MockContext();

            encryptor.Setup(e => e.GetSalt()).Returns(salt);
            encryptor.Setup(e => e.GetPassword(salt, "Password")).Returns(password);

            var userStore = new UserStore(context, encryptor.Object);

            userStore.AddUser(new User{ Username = "test" }, "Password");

            encryptor.Verify(e => e.GetSalt(), Times.Once);
            encryptor.Verify(e => e.GetPassword(salt, "Password"), Times.Once);

            Assert.AreEqual(1, context.Users.Count());
            var user = context.Users.First();
            Assert.AreEqual("test", user.Username);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(salt, user.Salt);
            Assert.AreEqual(1, context.SaveChangesCalls);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Username required")]
        public void Add_User_With_No_Username()
        {
            var context = new MockContext();
            var encrpytor = new Mock<IEncryptor>();
            var userStore = new UserStore(context, encrpytor.Object);

            userStore.AddUser(new User { Username = "" }, "Password");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Password required")]
        public void Add_User_With_No_Password()
        {
            var context = new MockContext();
            var encrpytor = new Mock<IEncryptor>();
            var userStore = new UserStore(context, encrpytor.Object);

            userStore.AddUser(new User { Username = "test" }, "");
        }

        [Test]
        public void Authenticate_No_User()
        {
            var context = new MockContext();
            var encrpytor = new Mock<IEncryptor>();
            var users = new Mock<DbSet<User>>();
            var userStore = new UserStore(context, encrpytor.Object);

            Assert.IsFalse(userStore.Authenticate("test", "test"));
        }

        [Test]
        public void Authenticate_User_Wrong_Password()
        {
            var context = new MockContext();
            var encrpytor = new Mock<IEncryptor>();
            context.Users.Add(new User { Username = "test" });
            var userStore = new UserStore(context, encrpytor.Object);

            Assert.IsFalse(userStore.Authenticate("test", "test"));
        }

        [Test]
        public void Authenticate_User()
        {
            var context = new MockContext();
            var encrpytor = new Mock<IEncryptor>();
            var salt = new byte[] { 1 };
            var password = new byte[] { 1, 2, 3, 4};
            context.Users.Add(new User{ 
                Username = "test", Password = password, Salt = salt 
            });
            encrpytor.Setup(e => e.GetPassword(salt, "test")).Returns(password);

            var userStore = new UserStore(context, encrpytor.Object);

            Assert.IsTrue(userStore.Authenticate("test", "test"));
        }

        [Test]
        public void Change_Email()
        {
            var context = new MockContext();
            var encryptor = new Mock<IEncryptor>();
            context.Users.Add(new User { Username = "test", Email = "test@test.com" });

            var userStore = new UserStore(context, encryptor.Object);

            userStore.ChangeEmail("test", "test2@test.com");

            var user = context.Users.First();
            Assert.AreEqual("test2@test.com", user.Email);
            Assert.AreEqual(1, context.SaveChangesCalls);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "User not found")]
        public void Change_Email_User_Not_Found()
        {
            var context = new MockContext();
            var encryptor = new Mock<IEncryptor>();

            var userStore = new UserStore(context, encryptor.Object);

            userStore.ChangeEmail("test", "test2@test.com");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "User not found")]
        public void Change_Password_User_Not_Found()
        {
            var context = new MockContext();
            var encryptor = new Mock<IEncryptor>();

            var userStore = new UserStore(context, encryptor.Object);

            userStore.ChangePassword("test", "newPassword");
        }

        [Test]
        public void Change_Password()
        {
            var context = new MockContext();
            context.Users.Add(new User
            { 
                Username = "test", 
                Password = new byte[] {1,2,3,4}, 
                Salt = new byte[] {1,2}
            });

            var encryptor = new Mock<IEncryptor>();
            encryptor.Setup(e => e.GetSalt()).Returns(new byte[] { 3, 4 });
            encryptor.Setup(e => e.GetPassword(new byte[] { 3, 4 }, "newPassword")).Returns(new byte[] { 5, 6, 7, 8 });

            var userStore = new UserStore(context, encryptor.Object);

            userStore.ChangePassword("test", "newPassword");

            encryptor.Verify(e => e.GetPassword(new byte[] { 3, 4 }, "newPassword"), Times.Once);
            encryptor.Verify(e => e.GetSalt(), Times.Once);
            var user = context.Users.First();
            Assert.AreEqual("test", user.Username);
            Assert.AreEqual(new byte[] { 5, 6, 7, 8 }, user.Password);
            Assert.AreEqual(new byte[] { 3, 4 }, user.Salt);
            Assert.AreEqual(1, context.SaveChangesCalls);
        }
    }
}