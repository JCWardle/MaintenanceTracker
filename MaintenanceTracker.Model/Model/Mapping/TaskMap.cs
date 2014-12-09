using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model.Mapping
{
    internal class TaskMap : EntityTypeConfiguration<Task>
    {
        internal TaskMap()
        {
            Property(t => t.Started).IsRequired();
        }
    }
}
