using System;
using System.Web.Mvc;
using AutoMapper;
using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;
using MaintenanceTracker.Web.App_Start;
using MaintenanceTracker.Web.Controllers;
using MaintenanceTracker.Web.ViewModels;
using Moq;
using NUnit.Framework;
namespace MaintenanceTracker.Tests.Web
{
    [TestFixture]
    public class UserControllerTests
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            MapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
        }

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

            var result = controller.Register(model);

            userStore.Verify(u => u.AddUser(It.IsAny<User>(), "abc"), Times.Once);
            Assert.IsInstanceOf(typeof(RedirectToRouteResult), result);
            var redirect = (RedirectToRouteResult) result;
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
            Assert.AreEqual("Home", redirect.RouteValues["controller"]);
        }

        [Test]
        public void Register_Shows_Register_Page()
        {
            var userStore = new Mock<IUserStore>();
            var controller = new UserController(userStore.Object);

            var result = controller.Register();

            Assert.IsInstanceOf(typeof(ViewResult), result);
            var view = (ViewResult) result;
            Assert.IsInstanceOf(typeof(RegisterViewModel), view.Model);
            var model = (RegisterViewModel) view.Model;
            Assert.IsNull(model.Email);
            Assert.IsNull(model.ConfirmPassword);
            Assert.IsNull(model.Password);
            Assert.IsNull(model.Username);
        }

        [Test]
        public void Cant_Register_Same_User_Twice()
        {
            var userStore = new Mock<IUserStore>();
            userStore.Setup(u => u.AddUser(It.IsAny<User>(), "abc")).Throws(new ArgumentException("Username already taken"));
            var controller = new UserController(userStore.Object);
            var model = new RegisterViewModel
            {
                ConfirmPassword = "abc",
                Password = "abc",
                Email = "test@abc.com",
                Username = "abc"
            };

            var result = controller.Register(model);

            userStore.Verify(u => u.AddUser(It.IsAny<User>(), "abc"), Times.Once);
            Assert.IsInstanceOf(typeof(ViewResult), result);
            var view = (RegisterViewModel)((ViewResult)result).Model;
            Assert.AreEqual("abc", view.Password);
            Assert.AreEqual("abc", view.ConfirmPassword);
            Assert.AreEqual("abc", view.Username);
            Assert.AreEqual("test@abc.com", view.Email);
        }

        []
    }
}
