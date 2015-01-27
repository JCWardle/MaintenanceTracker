using System.Collections.Generic;
using System.Web.Http;
using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;

namespace MaintenanceTracker.Web.Controllers
{
    [Authorize]
    public class VehicleController : ApiController
    {
        private IVehicleStore _store;
        private IUserProvider _userProvider;

        public VehicleController(IVehicleStore store, IUserProvider userProvider)
        {
            _store = store;
            _userProvider = userProvider;
        }

        public IEnumerable<Vehicle> Get()
        {
            return _store.ListVehicles(_userProvider.CurrentUserName());
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