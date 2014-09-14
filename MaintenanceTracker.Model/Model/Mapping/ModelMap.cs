using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model.Mapping
{
    internal class ModelMap : EntityTypeConfiguration<Model>
    {
        internal ModelMap()
        {
            HasKey(m => m.Id);

            Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();

            HasRequired(m => m.Make);

            ToTable("Model");
        }
    }
}
