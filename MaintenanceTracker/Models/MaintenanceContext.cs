using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class MaintenanceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VehicleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new LabourMap());
            modelBuilder.Configurations.Add(new PartMap());
            modelBuilder.Configurations.Add(new TaskMap());
        }

        public MaintenanceContext()
            : base("name=MaintenanceContext")
        { }
    }
}