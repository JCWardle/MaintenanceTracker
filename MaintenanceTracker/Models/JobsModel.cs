using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class JobsModel
    {
        public List<Job> JobList { get; set; }

        public Job NewMaintenance { get; set; }
    }
}