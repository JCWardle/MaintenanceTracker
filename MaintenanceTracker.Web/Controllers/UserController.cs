using MaintenanceTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTracker.Controllers
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
            return View();
        }
    }
}