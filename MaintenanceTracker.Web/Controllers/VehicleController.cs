using System.Collections.Generic;
using System.Web.Http;
using MaintenanceTracker.Domain;

namespace MaintenanceTracker.Web.Controllers
{
    [Authorize]
    public class VehicleController : ApiController
    {
        public VehicleController(IMaintenanceTrackerContext context)
        {
            
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}