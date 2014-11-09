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
    public class MaintenanceTrackerContext : DbContext, IMaintenanceTrackerContext
    {
            public virtual DbSet<Schedule> Schedules {get; set;}
            public virtual DbSet<VehicleModel> Models { get; set; }
            public virtual DbSet<Task> Tasks { get; set; }
            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<Part> Parts { get; set; }
            public virtual DbSet<Make> Makes { get; set; }
            public virtual DbSet<Vehicle> Vehicles { get; set; }

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
