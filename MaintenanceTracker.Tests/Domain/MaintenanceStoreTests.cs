using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;
using MaintenanceTracker.Tests.Domain.Context;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Tests.Domain
{
    [TestFixture]
    public class MaintenanceStoreTests
    {
        private Vehicle _vehicle = new Vehicle
        {
            Id = 1,
            Kilometres = 1000,
            User = new User { Id = 1, Username = "test" }
        };

        [Test]
        public void Add_Schedule()
        {
            var context = new MockContext();
            context.Vehicles.Add(_vehicle);
            var store = new MaintenanceStore(context);

            store.AddSchedule(1, new Schedule
            {
                Id = 1,
                Interval = 100,
                Notes = "Test",
                Parts = new List<Part>() { new Part { Id = 1, Cost = 2.00m, Name = "test" } },
                Title = "TestTitle"
            });

            Assert.AreEqual(1, context.Schedules.Count());
            var schedule = context.Schedules.First();
            Assert.AreEqual(1, schedule.Id);
            Assert.AreEqual(100, schedule.Interval);
            Assert.AreEqual("Test", schedule.Notes);
            Assert.AreEqual("TestTitle", schedule.Title);
            Assert.AreEqual(1, schedule.Parts.Count());
            var part = schedule.Parts.First();
            Assert.AreEqual(1, part.Id);
            Assert.AreEqual(2.00m, part.Cost);
            Assert.AreEqual("test", part.Name);
        }

        [Test, ExpectedException(ExpectedException = typeof(ArgumentException), ExpectedMessage = "Invalid Vehicle")]
        public void Add_Schedule_Invalid_Vehicle()
        {
            var context = new MockContext();
            var store = new MaintenanceStore(context);

            store.AddSchedule(0, new Schedule());
        }

        [Test]
        public void Add_Task()
        {
            var context = new MockContext();
            context.Vehicles.Add(_vehicle);
            var store = new MaintenanceStore(context);

            store.AddTask(1, new MaintenanceTracker.Domain.Model.Task
            {
                Id = 1,
                Notes = "Test Notes",
                Parts = new List<Part>() { new Part { Id = 1, Cost = 2.00m, Name = "test" } },
                Title = "TestTitle"
            });

            Assert.AreEqual(1, context.Tasks.Count());
            var task = context.Tasks.First();
            Assert.AreEqual(1, task.Id);
            Assert.AreEqual("Test Notes", task.Notes);
            Assert.AreEqual("TestTitle", task.Title);
            Assert.AreEqual(1, task.Parts.Count());
            var part = task.Parts.First();
            Assert.AreEqual(1, part.Id);
            Assert.AreEqual(2.00m, part.Cost);
            Assert.AreEqual("test", part.Name);
        }

        [Test, ExpectedException(ExpectedException = typeof(ArgumentException), ExpectedMessage = "Invalid Vehicle")]
        public void Add_Task_Invalid_Vehicle()
        {
            var context = new MockContext();
            var store = new MaintenanceStore(context);

            store.AddTask(0, new MaintenanceTracker.Domain.Model.Task());
        }
    }
}
