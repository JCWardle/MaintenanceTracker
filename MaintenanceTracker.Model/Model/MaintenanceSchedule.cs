using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model
{
    public class MaintenanceSchedule
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public string Notes { get; set; }
        public int Interval { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
