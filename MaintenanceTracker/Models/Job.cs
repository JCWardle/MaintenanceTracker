using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class Job
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Km { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<Labour> Labours { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }

    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            this.HasKey(j => j.ID);

            this.HasRequired(j => j.Vehicle);
            this.HasMany(j => j.Tasks);
        }
    }
}