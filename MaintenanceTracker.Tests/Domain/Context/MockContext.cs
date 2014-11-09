using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MaintenanceTracker.Tests.Domain.Context
{
    class MockContext : IMaintenanceTrackerContext
    {
        public MockContext()
        {
            Schedules = new MockDbSet<Schedule>();
            Models = new MockDbSet<Model>();
            Tasks = new MockDbSet<Task>();
            Users = new MockDbSet<User>();
            Parts = new MockDbSet<Part>();
            Makes = new MockDbSet<Make>();
            Vehicles = new MockDbSet<Vehicle>();
        }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public int SaveChanges()
        {
            return 1;
        }
    }
}