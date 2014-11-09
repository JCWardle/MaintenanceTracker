using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using VehicleModel = MaintenanceTracker.Domain.Model.Model;

namespace MaintenanceTracker.Domain
{
    public interface IMaintenanceTrackerContext
    {
        DbSet<Schedule> Schedules { get; set; }
        DbSet<VehicleModel> Models { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Part> Parts { get; set; }
        DbSet<Make> Makes { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        int SaveChanges();
    }
}
