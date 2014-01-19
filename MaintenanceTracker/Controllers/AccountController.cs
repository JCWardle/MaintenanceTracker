using BusinessLayer;
using MaintenanceTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MaintenanceTracker.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                using (var accountManager = new AccountManager())
                {
                    try
                    {
                        accountManager.CreateUser(model.Username, model.Password, model.Email);
                    }
                    catch(InvalidOperationException e)
                    {
                        model.Error = e.Message;
                    }
                }
            }

            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                using(var accountManager = new AccountManager())
                    if (accountManager.Login(model.Username, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, true);
                        return RedirectToAction("Index", "Home");
                    }
            }
            return View(model);
        }

        public ActionResult PasswordReminder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordReminder([Required]string email)
        {
            if(!String.IsNullOrWhiteSpace(email))
            {
                using(var accountManager = new AccountManager())
                {
                    if(accountManager.SendReminder(email))
                        return RedirectToAction("Login", "Account");
                    else
                        return View();
                }
            }
            return View();
        }
	}
}