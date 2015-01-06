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
            var model = new HomeViewModel
            {
                Login = new LoginViewModel(),
                Register = new RegisterViewModel()
            };
            return View(model);
        }

        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new HomeViewModel { Register = model, Login = new LoginViewModel() });
            }

            var user = Mapper.Map<User>(model);
            _userStore.AddUser(user, model.Password);
            return RedirectToAction("Index", "Home");
        }
    }
}