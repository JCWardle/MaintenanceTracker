using MaintenanceTracker.Domain;
using NUnit.Framework;
using System.Linq;

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
