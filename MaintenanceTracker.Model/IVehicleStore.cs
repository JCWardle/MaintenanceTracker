using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModel = MaintenanceTracker.Domain.Model.Model;

namespace MaintenanceTracker.Model
{
    public interface IVehicleStore
    {
        public void AddVehicle(int userId, Vehicle vehicle);
        public void AddModel(VehicleModel model);
        public void AddMake(Make make);
        public void DeleteVehicle(int userId, Vehicle vehicle);
        public IEnumerable<Vehicle> ListVehicles(int userId);
    }
}
