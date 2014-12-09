using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model
{
    public class Task : WorkItem
    {
        public DateTime Completed { get; set; }
        public DateTime Started { get; set; }
    }
}
