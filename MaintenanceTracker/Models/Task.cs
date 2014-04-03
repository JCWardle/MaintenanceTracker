using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual Job Job{get; set;}
    }

    public class TaskMap : EntityTypeConfiguration<Task>
    {
        public TaskMap()
        {
            this.HasKey(t => t.ID);

            this.HasRequired(t => t.Job).WithMany(j => j.Tasks).HasForeignKey(t => t.ID);
        }
    }
}