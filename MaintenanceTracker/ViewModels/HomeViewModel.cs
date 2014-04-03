using MaintenanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}