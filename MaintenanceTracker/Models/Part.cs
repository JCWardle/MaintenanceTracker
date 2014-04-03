using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public enum Units
    {
        Kilogram,
        Litre,
        Count,
        Metre
    }
    public class Part
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Retailer { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public Units Unit { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual Job Job { get; set; }
    }

    public class PartMap : EntityTypeConfiguration<Part>
    {
        public PartMap()
        {
            this.HasKey(p => p.ID);
            this.HasRequired(p => p.Job).WithMany(j => j.Parts).HasForeignKey(p => p.ID);
        }
    }
}