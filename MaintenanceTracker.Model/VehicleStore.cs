using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain
{
    public class VehicleStore : IVehicleStore, IDisposable
    {
        MaintenanceTrackerContext _context;

        public VehicleStore(MaintenanceTrackerContext context)
        {
            _context = context;
        }

        public void AddVehicle(int userId, Model.Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void AddModel(Model.Model model)
        {
            throw new NotImplementedException();
        }

        public void AddMake(Model.Make make)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int userId, Model.Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Vehicle> ListVehicles(int userId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
