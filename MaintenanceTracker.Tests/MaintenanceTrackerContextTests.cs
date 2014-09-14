using MaintenanceTracker.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Tests
{
    [TestFixture]
    public class MaintenanceTrackerContextTests
    {
        [Test]
        public void CreateDatabase()
        {
            using (var context = new MaintenanceTrackerContext())
            {
                var vehicles = context.Vehicles;
                Assert.AreEqual(vehicles.Count(), 0);
            }
        }
    }
}
