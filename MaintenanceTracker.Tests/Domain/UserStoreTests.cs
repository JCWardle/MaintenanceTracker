using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Tests.Domain
{
    [TestFixture]
    public class UserStoreTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Username already taken")]
        public void Add_Duplicate_Username()
        {
            var data = new List<User>() {
                new User { Username= "test" }
            }.AsQueryable();
            var users = new Mock<DbSet<User>>();
            
            var encryptor = new Mock<IEncryptor>();
            var context = new Mock<MaintenanceTrackerContext>();            
            context.Setup(c => c.Users).Returns(MoqUserList(data, users).Object);
            var userStore = new UserStore(context.Object, encryptor.Object);

            userStore.AddUser(new User
            {
                Username = "test"
            }, "password");
        }

        [Test]
        public void Password_Gets_Encrypted()
        {
            var context = new Mock<MaintenanceTrackerContext>();
            var salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var password = new byte[] { 5, 6, 7, 8 };
            var data = new List<User>().AsQueryable();
            var users = new Mock<DbSet<User>>();
            var encryptor = new Mock<IEncryptor>();

            context.Setup(c => c.Users).Returns(MoqUserList(data, users).Object);
            encryptor.Setup(e => e.GetSalt()).Returns(salt);
            encryptor.Setup(e => e.GetPassword(salt, "Password")).Returns(password);

            var userStore = new UserStore(context.Object, encryptor.Object);

            userStore.AddUser(new User{
                Username = "test"
            }, "Password");

            encryptor.Verify(e => e.GetSalt(), Times.Once);
            encryptor.Verify(e => e.GetPassword(salt, "Password"), Times.Once);
            users.Verify(u => u.Add(It.IsAny<User>()), Times.Once);
            context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Username required")]
        public void Add_User_With_No_Username()
        {
            var context = new Mock<MaintenanceTrackerContext>();
            var encrpytor = new Mock<IEncryptor>();
            var userStore = new UserStore(context.Object, encrpytor.Object);

            userStore.AddUser(new User
            {
                Username = ""
            }, "Password");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Password required")]
        public void Add_User_With_No_Password()
        {
            var context = new Mock<MaintenanceTrackerContext>();
            var encrpytor = new Mock<IEncryptor>();
            var userStore = new UserStore(context.Object, encrpytor.Object);

            userStore.AddUser(new User 
            {
                Username = "test"
            }, "");
        }

        [Test]
        public void Authenticate_No_User()
        {
            var context = new Mock<MaintenanceTrackerContext>();
            var encrpytor = new Mock<IEncryptor>();
            var data = new List<User>().AsQueryable();
            var users = new Mock<DbSet<User>>();

            context.Setup(c => c.Users).Returns(MoqUserList(data, users).Object);
            var userStore = new UserStore(context.Object, encrpytor.Object);

            Assert.IsFalse(userStore.Authenticate("test", "test"));
        }

        [Test]
        public void Authenticate_User_Wrong_Password()
        {
            var context = new Mock<MaintenanceTrackerContext>();
            var encrpytor = new Mock<IEncryptor>();
            var data = new List<User>()
            {
                new User { Username = "test" }
            }.AsQueryable();
            var users = new Mock<DbSet<User>>();

            context.Setup(c => c.Users).Returns(MoqUserList(data, users).Object);
            var userStore = new UserStore(context.Object, encrpytor.Object);

            Assert.IsFalse(userStore.Authenticate("test", "test"));
        }

        [Test]
        public void Authenticate_User()
        {
            var context = new Mock<MaintenanceTrackerContext>();
            var encrpytor = new Mock<IEncryptor>();
            var salt = new byte[] { 1 };
            var password = new byte[] { 1, 2, 3, 4};
            var data = new List<User>()
            {
                new User { Username = "test", Password = password, Salt = salt }
            }.AsQueryable();
            var users = new Mock<DbSet<User>>();
            encrpytor.Setup(e => e.GetPassword(salt, "test")).Returns(password);

            context.Setup(c => c.Users).Returns(MoqUserList(data, users).Object);
            var userStore = new UserStore(context.Object, encrpytor.Object);

            Assert.IsTrue(userStore.Authenticate("test", "test"));
        }

        [Test]
        public void Change_Email()
        {
            var context = new Mock<MaintenanceTrackerContext>();
            var encryptor = new Mock<IEncryptor>();
            var data = new List<User>()
            {
                new User { Username = "test", Email = "test@test.com" }
            }.AsQueryable();
            var users = new Mock<DbSet<User>>();
            context.Setup(c => c.Users).Returns(MoqUserList(data, users).Object);

            var userStore = new UserStore(context.Object, encryptor.Object);

            userStore.ChangeEmail("test", "test2@test.com");

            context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "User not found")]
        public void Change_Email_User_Not_Found()
        {
            var context = new Mock<MaintenanceTrackerContext>();
            var encryptor = new Mock<IEncryptor>();
            var data = new List<User>().AsQueryable();
            var users = new Mock<DbSet<User>>();
            context.Setup(c => c.Users).Returns(MoqUserList(data, users).Object);

            var userStore = new UserStore(context.Object, encryptor.Object);

            userStore.ChangeEmail("test", "test2@test.com");
        }

        private Mock<DbSet<User>> MoqUserList(IQueryable<User> data, Mock<DbSet<User>> users)
        {
            users.As<IQueryable<User>>().Setup(u => u.Provider).Returns(data.Provider);
            users.As<IQueryable<User>>().Setup(u => u.Expression).Returns(data.Expression);
            users.As<IQueryable<User>>().Setup(u => u.ElementType).Returns(data.ElementType);
            users.As<IQueryable<User>>().Setup(u => u.GetEnumerator()).Returns(data.GetEnumerator());
            return users;
        }
    }
}