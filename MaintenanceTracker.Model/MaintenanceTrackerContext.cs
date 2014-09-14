using MaintenanceTracker.Domain.Model;
using MaintenanceTracker.Domain.Model.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using VehicleModel = MaintenanceTracker.Domain.Model.Model;

namespace MaintenanceTracker.Domain
{
    public class MaintenanceTrackerContext : DbContext
    {
            public DbSet<Schedule> Schedules {get; set;}
            public DbSet<VehicleModel> Models { get; set; }
            public DbSet<Task> Tasks { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Part> Parts { get; set; }
            public DbSet<Make> Makes { get; set; }
            public DbSet<Vehicle> Vehicles { get; set; }

            public MaintenanceTrackerContext() { }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new MakeMap());
                modelBuilder.Configurations.Add(new ModelMap());
                modelBuilder.Configurations.Add(new PartMap());
                modelBuilder.Configurations.Add(new ScheduleMap());
                modelBuilder.Configurations.Add(new UserMap());
                modelBuilder.Configurations.Add(new VehicleMap());
                modelBuilder.Configurations.Add(new TaskMap());
            }
    }
}
