using System;
using AutoMapper;
using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;
using MaintenanceTracker.Web.ViewModels;
using System.Web.Mvc;

namespace MaintenanceTracker.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserStore _userStore;

        public UserController(IUserStore userStore)
        {
            _userStore = userStore;
        }

        public ActionResult Index()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = Mapper.Map<User>(model);
            try
            {
                _userStore.AddUser(user, model.Password);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}