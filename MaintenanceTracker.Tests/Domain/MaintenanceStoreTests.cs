using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;
using MaintenanceTracker.Tests.Domain.Context;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceTask = MaintenanceTracker.Domain.Model.Task;

namespace MaintenanceTracker.Tests.Domain
{
    [TestFixture]
    public class MaintenanceStoreTests
    {
        private Vehicle _vehicle = new Vehicle
        {
            Id = 1,
            Kilometers = 1000,
            User = new User { Id = 1, Username = "test" }
        };

        private List<Schedule> _schedules = new List<Schedule>();
        private List<MaintenanceTask> _tasks = new List<MaintenanceTask>();

        public MaintenanceStoreTests()
        {
            var otherVehicle = new Vehicle { Id = 2, Kilometers = 2000, User = new User { Id = 2, Username = "test2" } };
            _schedules.Add(new Schedule { Id = 1, Title = "Oil", Vehicle = _vehicle });
            _schedules.Add(new Schedule { Id = 2, Title = "Spark Plug", Vehicle = _vehicle });
            _schedules.Add(new Schedule { Id = 3, Title = "Cable", Vehicle = _vehicle });
            _schedules.Add(new Schedule { Id = 4, Title = "Exhaust", Vehicle = otherVehicle });
            _schedules.Add(new Schedule { Id = 5, Title = "Intake", Vehicle = otherVehicle });

            _tasks.Add(new MaintenanceTask { Id = 6, Title = "Tyre", Vehicle = _vehicle, Started = new DateTime(2013, 7, 1) });
            _tasks.Add(new MaintenanceTask { Id = 7, Title = "Chain", Vehicle = _vehicle, Started = new DateTime(2013, 7, 2) });
            _tasks.Add(new MaintenanceTask { Id = 8, Title = "Sproket", Vehicle = _vehicle, Started = new DateTime(2013, 7, 3) });
            _tasks.Add(new MaintenanceTask { Id = 9, Title = "Seat", Vehicle = otherVehicle, Started = new DateTime(2013, 7, 4) });
            _tasks.Add(new MaintenanceTask { Id = 10, Title = "Air Filter", Vehicle = otherVehicle, Started = new DateTime(2013, 7, 5) });
        }

        [Test]
        public void Add_Schedule()
        {
            var context = new MockContext();
            context.Vehicles.Add(_vehicle);
            var store = new MaintenanceStore(context);

            store.AddWorkItem(1, new Schedule
            {
                Id = 1,
                DistanceInterval = 100,
                Notes = "Test",
                Parts = new List<Part>() { new Part { Id = 1, Cost = 2.00m, Name = "test" } },
                Title = "TestTitle"
            });

            Assert.AreEqual(1, context.Schedules.Count());
            var schedule = context.Schedules.First();
            Assert.AreEqual(1, schedule.Id);
            Assert.AreEqual(100, schedule.DistanceInterval);
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

            store.AddWorkItem(0, new Schedule());
        }

        [Test]
        public void Add_Task()
        {
            var context = new MockContext();
            context.Vehicles.Add(_vehicle);
            var store = new MaintenanceStore(context);

            store.AddWorkItem(1, new MaintenanceTracker.Domain.Model.Task
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

            store.AddWorkItem(0, new MaintenanceTracker.Domain.Model.Task());
        }

        [Test]
        public void List_All_Schedules()
        {
            var context = new MockContext();
            context.Schedules.Add(_schedules[0]);
            context.Schedules.Add(_schedules[1]);
            var store = new MaintenanceStore(context);

            var result = store.GetSchedules(_vehicle.Id).ToList();

            Assert.AreEqual(2, result.Count);
            var schedule1 = result[0];
            Assert.AreEqual(1, schedule1.Id);
            Assert.AreEqual(_vehicle, schedule1.Vehicle);
            Assert.AreEqual("Oil", schedule1.Title);

            var schedule2 = result[1];
            Assert.AreEqual(2, schedule2.Id);
            Assert.AreEqual(_vehicle, schedule2.Vehicle);
            Assert.AreEqual("Spark Plug", schedule2.Title);
        }

        [Test]
        public void List_All_Tasks()
        {
            var context = new MockContext();
            context.Tasks.Add(_tasks[0]);
            context.Tasks.Add(_tasks[1]);
            var store = new MaintenanceStore(context);

            var result = store.GetTasks(_vehicle.Id).ToList();

            Assert.AreEqual(2, result.Count);
            var task1 = result[0];
            Assert.AreEqual(6, task1.Id);
            Assert.AreEqual(_vehicle, task1.Vehicle);
            Assert.AreEqual("Tyre", task1.Title);

            var task2 = result[1];
            Assert.AreEqual(7, task2.Id);
            Assert.AreEqual(_vehicle, task2.Vehicle);
            Assert.AreEqual("Chain", task2.Title);
        }
    }
}
