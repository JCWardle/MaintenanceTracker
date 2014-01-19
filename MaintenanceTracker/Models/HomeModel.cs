using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class HomeModel
    {
        public IList<VehicleModel> Vehicles { get; set; }
        public VehicleModel NewVehicle { get; set; }

        public HomeModel()
        {
            Vehicles = new List<VehicleModel>();
        }
    }
}