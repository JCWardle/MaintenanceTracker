using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model.Mapping
{
    internal class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        internal VehicleMap()
        {
            HasKey(v => v.Id);

            HasRequired(v => v.Model);

            HasMany(v => v.WorkItems)
                .WithRequired(s => s.Vehicle)
                .Map(m => m.MapKey("WorkItemId"));

            HasRequired(v => v.User)
                .WithMany(u => u.Vehicles)
                .Map(m => m.MapKey("UserId"));

            Property(v => v.Year)
                .HasMaxLength(4)
                .IsRequired();

            ToTable("Vehicle");
        }
    }
}
