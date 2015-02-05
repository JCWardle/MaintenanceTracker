using System.Collections.Generic;
using System.Web.Http;
using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;

namespace MaintenanceTracker.Web.Controllers
{
    public class VehicleController : ApiController
    {
        private IVehicleStore _store;
        private IUserProvider _userProvider;

        public VehicleController(IVehicleStore store, IUserProvider userProvider)
        {
            _store = store;
            _userProvider = userProvider;
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _store.ListVehicles(_userProvider.CurrentUserName());
        }

        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put([FromBody]Vehicle value)
        {
            _store.AddVehicle(_userProvider.CurrentUserName(), value);
        }

        public void Delete(int id)
        {
        }
    }
}