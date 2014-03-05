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
        [Authorize]
        public ActionResult Index(int id)
        {
            using(var vehicleManager = new VehicleManager())
            {
                if(vehicleManager.VehicleBelongsToUser(id, HttpContext.User.Identity.Name))
                {
                    var model = new JobsModel
                    {
                        NewJob = new Job(),
                        JobList = vehicleManager.GetJobs(id),
                        VehicleName = vehicleManager.GetName(id)
                    };
                    return View(model);
                }
                else
                    return RedirectToAction("Index", "Home");
            }
        }
	}
}