using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class Vehicle
    {
        public int ID {get; set;}
        [Required]
        [Display (Name = "Make")]
        public string Make { get; set; }
        [Required]
        [Display (Name = "Model")]
        public string Model { get; set; }
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        [Display (Name = "Year")]
        public string Year { get; set; }
        [Display (Name = "Registration")]
        public string Registration { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            this.HasKey(v => v.ID);

            this.HasRequired(v => v.User).WithMany(s => s.Vehicles).HasForeignKey(u => u.UserId);
        }
    }
}