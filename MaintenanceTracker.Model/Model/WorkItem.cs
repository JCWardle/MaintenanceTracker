using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model
{
    public class WorkItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public string Notes { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
