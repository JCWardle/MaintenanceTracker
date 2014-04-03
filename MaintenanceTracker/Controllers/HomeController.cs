using MaintenanceTracker.Models;
using MaintenanceTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MaintenanceTracker.Controllers
{
    [Authorize]
    public class HomeController : SiteController
    {
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            using(var context = new MaintenanceContext())
            {
                if(Session["UserID"] == null)
                {
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Login", "Account");
                }
                var userID = (int)Session["UserID"];
                var model = new HomeViewModel()
                {
                    Vehicle = new Vehicle(),
                    Vehicles = context.Vehicles.Where(v => v.User.Username == User.Identity.Name).ToList()
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {          
            if (ModelState.IsValid)
            {
                using (var context = new MaintenanceContext())
                {
                    context.Users.Where(u => u.Username == User.Identity.Name).First().Vehicles.Add(model.Vehicle);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            using (var context = new MaintenanceContext())
            {
                model.Vehicles = context.Vehicles.Where(v => v.User.Username == User.Identity.Name).ToList();
            }
            return View(model);
        }
	}
}