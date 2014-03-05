using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VehicleManager : IDisposable
    {
        private MaintenanceTrackerEntities _context;

        public VehicleManager()
        {
            _context = new MaintenanceTrackerEntities();
        }

        public void AddVehicle(string username, string model, string make, string year, string registration)
        {
            var user = _context.Users.First(u => u.Username == username);

            user.Vehicles.Add(new Vehicle
            {
                Make = make,
                Year = DateTime.ParseExact(year, "yyyy", CultureInfo.InvariantCulture),
                Registration = registration,
                Model = model
            });

            _context.SaveChanges();
        }

        public IEnumerable<Vehicle> GetVehicles(string username)
        {
            var userid = _context.Users.First(u => u.Username == username).UserId;
            return _context.Vehicles.Where(v => v.UserId == userid);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public bool VehicleBelongsToUser(int vehicleId, string username)
        {
            return _context.Users.Where(u => u.Username == username).First().Vehicles.Any(v => v.VehicleId == vehicleId);
        }

        public IEnumerable<Job> GetJobs(int vehicleId)
        {
            return _context.Jobs.Where(m => m.VehicleId == vehicleId).ToList();
        }

        public string GetName(int id)
        {
            var vehicle = _context.Vehicles.Where(v => v.VehicleId == id).First();
            return String.Format("{0} {1}", vehicle.Model, vehicle.Year);
        }
    }
}