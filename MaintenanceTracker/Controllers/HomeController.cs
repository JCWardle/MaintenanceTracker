using BusinessLayer;
using MaintenanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTracker.Controllers
{
    public class HomeController : SiteController
    {
        //
        // GET: /Home/
        [Authorize]
        public ActionResult Index()
        {
            using(var vehicleManager = new VehicleManager())
            {
                var vehicles = vehicleManager.GetVehicles(HttpContext.User.Identity.Name);
                var model = new HomeModel();

                foreach(var v in vehicles)
                {
                    model.Vehicles.Add(VehicleModel.ConvertVehicle(v));
                }

                return View(model);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Index(HomeModel vehicle)
        {
            using (var vehicleManager = new VehicleManager())
            {
                if (ModelState.IsValid)
                {
                    vehicleManager.AddVehicle(
                        HttpContext.User.Identity.Name,
                        vehicle.NewVehicle.Model,
                        vehicle.NewVehicle.Make,
                        vehicle.NewVehicle.Year,
                        vehicle.NewVehicle.Registration
                        );
                    return RedirectToAction("Index", "Home");
                }
                else
                    foreach (var v in vehicleManager.GetVehicles(HttpContext.User.Identity.Name))
                        vehicle.Vehicles.Add(VehicleModel.ConvertVehicle(v));
            }
            return View(vehicle);
        }
	}
}