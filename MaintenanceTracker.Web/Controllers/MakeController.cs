using MaintenanceTracker.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MaintenanceTracker.Domain;

namespace MaintenanceTracker.Web.Controllers
{
    public class MakeController : ApiController
    {
        private IVehicleStore _store;

        public MakeController(IVehicleStore store)
        {
            _store = store;
        }

        // GET api/<controller>
        public IEnumerable<Make> Get()
        {
            return _store.ListMakes();
        }

        // GET api/<controller>/5
        public Make Get(int id)
        {
            return _store.ListMakes().First();
        }

        // POST api/<controller>
        public void Post([FromBody]Make value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Make value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}