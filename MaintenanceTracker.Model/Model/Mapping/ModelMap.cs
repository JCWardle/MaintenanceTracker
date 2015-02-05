using System.Data.Entity.ModelConfiguration;

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

            HasRequired(m => m.Make)
                .WithMany(m => m.Models);

            ToTable("Model");
        }
    }
}
