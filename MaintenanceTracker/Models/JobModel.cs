using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class JobModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Km { get; set; }
    }
}