using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class JobsModel
    {
        public IEnumerable<Job> JobList { get; set; }

        public JobModel NewJob { get; set; }

        public string VehicleName { get; set; }
    }
}