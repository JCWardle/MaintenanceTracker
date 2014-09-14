using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model.Mapping
{
    internal class PartMap : EntityTypeConfiguration<Part>
    {
        internal PartMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .HasMaxLength(512);

            Property(p => p.Reciept)
                .IsOptional()
                .HasMaxLength(256);

            Property(p => p.Retailer)
                .IsOptional()
                .HasMaxLength(512);

            HasOptional(p => p.Schedule)
                .WithMany(p => p.Parts)
                .Map(m => m.MapKey("ScheduleId"));

            HasOptional(p => p.Task)
                .WithMany(p => p.Parts)
                .Map(m => m.MapKey("TaskId"));

            ToTable("Part");
        }
    }
}
