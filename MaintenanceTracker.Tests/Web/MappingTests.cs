using AutoMapper;
using MaintenanceTracker.Web.App_Start;
using NUnit.Framework;

namespace MaintenanceTracker.Tests.Web
{
    [TestFixture]
    public class MappingTests
    {
        [Test]
        public void TestMapping()
        {
            MapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
