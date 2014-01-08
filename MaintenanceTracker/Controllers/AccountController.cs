using BusinessLayer;
using MaintenanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTracker.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                using (var accountManager = new AccountManager())
                {
                    accountManager.CreateUser(model.UserName, model.Password, model.Email);
                }
            }

            return View(model);
        }
	}
}