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
            HasKey(t => t.Id);

            Property(t => t.Title)
                .HasMaxLength(50);

            Property(t => t.Notes)
                .HasMaxLength(2048);
        }
    }
}
