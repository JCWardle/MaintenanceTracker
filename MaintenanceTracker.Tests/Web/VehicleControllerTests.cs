using MaintenanceTracker.Domain;
using MaintenanceTracker.Web;
using MaintenanceTracker.Web.Controllers;
using NUnit.Framework;
using Moq;

namespace MaintenanceTracker.Tests.Web
{
    [TestFixture]
    public class VehicleControllerTests
    {
        [Test]
        public void Get_Returns_Vehicles_For_User_Only()
        {
            var userProvider = new Mock<IUserProvider>();
            var vehicleStore = new Mock<IVehicleStore>();
            var controller = new VehicleController(vehicleStore.Object, userProvider.Object);

            var result = controller.Get();
        }

        [Test]
        public void Gets_All_Vehicles()
        {
            
        }

        [Test]
        public void Gets_Individual_Vehicle()
        {
            
        }

        [Test]
        public void Creates_New_Vehicle()
        {
            
        }
    }
}
