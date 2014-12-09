using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model
{
    public class Schedule : WorkItem
    {
        public DateTime TimeInterval { get; set; }
        public int DistanceInterval { get; set; }
    }
}
