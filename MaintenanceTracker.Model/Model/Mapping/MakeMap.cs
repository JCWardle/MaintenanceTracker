using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model.Mapping
{
    internal class MakeMap : EntityTypeConfiguration<Make>
    {
        internal MakeMap()
        {
            ToTable("Make");

            HasKey(m => m.Id);

            Property(m => m.Name)
                .HasMaxLength(256)
                .IsRequired();

            HasMany(m => m.Models)
                .WithRequired(m => m.Make)
                .Map(m => m.MapKey("ModelId"));            
        }
    }
}
