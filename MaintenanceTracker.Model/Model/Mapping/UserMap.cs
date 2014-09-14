using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model.Mapping
{
    internal class UserMap : EntityTypeConfiguration<User>
    {
        internal UserMap()
        {
            HasKey(u => u.Id);

            HasMany(u => u.Vehciles);

            Property(u => u.Username)
                .HasMaxLength(14);

            Property(u => u.Password)
                .HasMaxLength(126);

            Property(e => e.Email)
                .HasMaxLength(256);

            ToTable("User");
        }
    }
}
