using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model.Mapping
{
    internal class ScheduleMap : EntityTypeConfiguration<Schedule>
    {
        internal ScheduleMap()
        {
            HasKey(s => s.Id);

            HasRequired(s => s.Vehicle);

            HasMany(s => s.Parts);

            Property(s => s.Title)
                .HasMaxLength(50)
                .IsRequired();

            Property(s => s.Interval)
                .IsRequired();

            ToTable("Schedule");
        }
    }
}
