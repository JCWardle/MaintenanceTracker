using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MaintenanceTracker.Domain;
using MaintenanceTracker.Domain.Model;

namespace MaintenanceTracker.Web.Controllers
{
    public class ModelController : ApiController
    {
        private IVehicleStore _store;

        public ModelController(IVehicleStore store)
        {
            _store = store;
        }
        // GET api/<controller>
        public IEnumerable<Model> Get()
        {
            return _store.ListModels().ToArray();
        }

        // GET api/<controller>/5
        public dynamic Get(string make)
        {
            return _store.ListModels().Where(m => m.Make.Name == make).Select(m => new { Name = m.Name, Id = m.Id }).ToArray();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}