using BusinessLayer;
using MaintenanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTracker.Controllers
{
    public class JobController : SiteController
    {
        //
        // GET: /Maintenace/
        [Authorize]
        public ActionResult Index(int vehicleId)
        {
            using(var vehicleManager = new VehicleManager())
            {
                if(vehicleManager.VehicleBelongsToUser(vehicleId, HttpContext.User.Identity.Name))
                {
                    var maintenance = vehicleManager.GetMaintenance(vehicleId);
                    return View(maintenance);
                }
                else
                    return RedirectToAction("Index", "Home");
            }
        }
	}
}