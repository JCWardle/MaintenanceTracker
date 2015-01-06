﻿using System.Runtime.Remoting.Metadata.W3cXsd2001;
using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;
using MaintenanceTracker.Web.Controllers;
using MaintenanceTracker.Web.ViewModels;
using Moq;
using NUnit.Framework;
namespace MaintenanceTracker.Tests.Web
{
    [TestFixture]
    public class UserControllerTests
    {
        [Test]
        public void Register_User()
        {
            var userStore = new Mock<IUserStore>();
            userStore.Setup(u => u.AddUser(It.IsAny<User>(), "abc"));
            var controller = new UserController(userStore.Object);
            var model = new RegisterViewModel
            {
                ConfirmPassword = "abc",
                Password = "abc",
                Email = "test@abc.com",
                Username = "abc"
            };

            controller.Register(model);

            userStore.Verify(u => u.AddUser(It.IsAny<User>(), "abc"), Times.Once);
        }
    }
}