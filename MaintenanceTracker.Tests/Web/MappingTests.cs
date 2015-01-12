using AutoMapper;
using MaintenanceTracker.Web.App_Start;
using NUnit.Framework;

namespace MaintenanceTracker.Tests.Web
{
    [TestFixture]
    public class MappingTests
    {
        [Test]
        public void Test_Mapping()
        {
            MapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
