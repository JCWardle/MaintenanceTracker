using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class Labour
    {
        public int ID { get; set; }
        public int Time { get; set; }
        public decimal CostPerHour { get; set; }
        public virtual Job Job { get; set; }
    }

    public class LabourMap : EntityTypeConfiguration<Labour>
    {
        public LabourMap()
        {
            this.HasKey(l => l.ID);

            this.HasRequired(l => l.Job).WithMany(j => j.Labours).HasForeignKey(l => l.ID);
        }
    }
}