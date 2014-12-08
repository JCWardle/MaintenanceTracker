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
    public class VehicleStoreTests
    {
        private Model _model = new Model
        {
            Id = 1,
            Make = new Make
            {
                Id = 1,
                Name = "Chonda"
            },
            Name = "ceebee250"
        };

        private User _user = new User
        {
            Username = "test",
            Id = 1
        };

        private Make _make = new Make
        {
            Id = 1,
            Name = "kwaka"
        };

        [Test]
        public void Add_Valid_Vehicle()
        {
            var context = new MockContext();
            context.Models.Add(_model);
            context.Users.Add(_user);
            var store = new VehicleStore(context);
            var vehicle = new Vehicle
            {
                Kilometres = 7000,
                Model = context.Models.First(),
                Year = "1991"
            };

            store.AddVehicle(1, vehicle);

            vehicle = context.Vehicles.First();
            Assert.AreEqual(7000, vehicle.Kilometres);
            Assert.AreEqual(context.Models.First(), vehicle.Model);
            Assert.AreEqual("1991", vehicle.Year);
            Assert.AreEqual(1, context.SaveChangesCalls);
        }

        [Test, ExpectedException(ExpectedException = typeof(ArgumentException), ExpectedMessage = "Invalid User" )]
        public void Add_Vehicle_Invalid_User()
        {
            var context = new MockContext();
            context.Models.Add(_model);
            context.Users.Add(_user);
            var store = new VehicleStore(context);
            var vehicle = new Vehicle
            {
                Kilometres = 7000,
                Model = context.Models.First(),
                Year = "1991"
            };
            
            store.AddVehicle(2, vehicle);
        }

        [Test]
        public void Add_Model()
        {
            var context = new MockContext();
            var store = new VehicleStore(context);

            store.AddModel(new Model
            {
                Id = 2,
                Make = _make,
                Name = "Klaker"
            });

            var model = context.Models.First();
            Assert.AreEqual(2, model.Id);
            Assert.AreEqual(_make, model.Make);
            Assert.AreEqual("Klaker", model.Name);
            Assert.AreEqual(1, context.SaveChangesCalls);
        }

        [Test, ExpectedException(ExpectedException = typeof(ArgumentException), ExpectedMessage = "That model already exists")]
        public void Add_Duplicate_Model()
        {
            var context = new MockContext();
            var store = new VehicleStore(context);

            var model = new Model()
            {
                Id = 2,
                Make = _make,
                Name = "Klaker"
            };

            context.Models.Add(model);
            model.Id = 3;

            store.AddModel(model);
        }

        [Test]
        public void Duplicate_Model_Different_Make()
        {
            var context = new MockContext();
            var store = new VehicleStore(context);

            var model = new Model()
            {
                Id = 2,
                Make = _make,
                Name = "Klaker"
            };

            context.Models.Add(model);
            model.Make = new Make()
            {
                Id = 3,
                Name = "Suzoooki"
            };

            store.AddModel(model);

            model = context.Models.Last();
            Assert.AreEqual(2, model.Id);
            Assert.AreEqual("Klaker", model.Name);

            var make = model.Make;
            Assert.AreEqual(3, make.Id);
            Assert.AreEqual("Suzoooki", make.Name);
            Assert.AreEqual(1, context.SaveChangesCalls);
        }

        [Test]
        public void Add_Make()
        {
            var context = new MockContext();
            var store = new VehicleStore(context);

            store.AddMake(new Make
            {
                Id = 1,
                Name = "Cowaskai"
            });

            var make = context.Makes.First();
            Assert.AreEqual(1, make.Id);
            Assert.AreEqual("Cowaskai", make.Name);
            Assert.AreEqual(1, context.SaveChangesCalls);
        }

        [Test, ExpectedException( ExpectedException = typeof(ArgumentException), ExpectedMessage = "The make already exists")]
        public void Add_Duplicate_Make()
        {
            var context = new MockContext();
            var store = new VehicleStore(context);
            var make = new Make
            {
                Id = 1,
                Name = "cow"
            };
            context.Makes.Add(make);

            make.Id = 2;
            store.AddMake(make);
        }

        [Test]
        public void Delete_Vehicle()
        {
            var context = new MockContext();
            var vehicle = new Vehicle { Id = 1, User = _user};
            context.Vehicles.Add(vehicle);
            var store = new VehicleStore(context);

            store.DeleteVehicle(_user.Id, 1);

            Assert.AreEqual(0, context.Vehicles.Count());
        }

        [Test, ExpectedException(ExpectedException = typeof(ArgumentException), ExpectedMessage = "Invalid user id")]
        public void Delete_Vehicle_Wrong_User()
        {
            var context = new MockContext();
            var vehicle = new Vehicle { Id = 1, User = _user };
            context.Vehicles.Add(vehicle);
            var store = new VehicleStore(context);

            store.DeleteVehicle(2, 1);
        }

        [Test, ExpectedException(ExpectedException = typeof(ArgumentException), ExpectedMessage = "Invalid Vehicle Id")]
        public void Delete_Vehicle_Wrong_Vehicle()
        {
            var context = new MockContext();
            var vehicle = new Vehicle { Id = 1, User = _user };
            context.Vehicles.Add(vehicle);
            var store = new VehicleStore(context);

            store.DeleteVehicle(2, 2);
        }
    }
}
