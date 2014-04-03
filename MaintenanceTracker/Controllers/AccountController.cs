using MaintenanceTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MaintenanceTracker.Controllers
{
    public class AccountController : SiteController
    {
        private const int SALT_SIZE = 8;

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new MaintenanceContext())
                {
                    if (!context.Users.Any(u => u.Username == model.Username))
                    {
                        model.Salt = GenerateRandomString(SALT_SIZE);
                        model.Password = GetHash(string.Concat(model.Password, model.Salt));
                        
                        context.Users.Add(model);
                        context.SaveChanges();
                        return RedirectToAction("Login", "Account");
                    }
                    else
                        ModelState.AddModelError("Username", "Someone has already taken that user name!");
                }
            }
            return View(model);
        }
        public ActionResult Login()
        {
            return View(new User());
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (String.IsNullOrEmpty(model.Username) && String.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Invalid", "Invalid username and password");
            }
            else
                using (var context = new MaintenanceContext())
                {
                    if(context.Users.Any(u => u.Username == model.Username))
                    {
                        var user = context.Users.Where(u => u.Username == model.Username).First();

                        if (GetHash(string.Concat(model.Password, user.Salt)) == user.Password)
                        {
                            Session["UserID"] = user.ID;
                            FormsAuthentication.SetAuthCookie(model.Username, true);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                            ModelState.AddModelError("Invalid", "Invalid username and password");
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
            throw new NotImplementedException();
        }

        private string GetHash(string password)
        {
            using (var hash = MD5.Create())
            {
                var data = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();

                for (var i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public string GenerateRandomString(int size)
        {
            var rand = new Random();
            var result = new StringBuilder();

            for (int i = 0; i < size; i++)
                result.Append(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));

            return result.ToString();
        }       
	}
}