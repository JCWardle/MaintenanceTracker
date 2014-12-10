using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceTask = MaintenanceTracker.Domain.Model.Task;

namespace MaintenanceTracker.Domain
{
    public class MaintenanceStore : IMaintenanceStore, IDisposable
    {
        IMaintenanceTrackerContext _context;
        public MaintenanceStore(IMaintenanceTrackerContext context)
        {
            _context = context;
        }
        
        public void AddWorkItem(int vehicleId, Model.WorkItem item)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle == null)
                throw new ArgumentException("Invalid Vehicle");

            item.Vehicle = vehicle;
            if (item.GetType() == typeof(Schedule))
                _context.Schedules.Add((Schedule)item);
            else
                _context.Tasks.Add((MaintenanceTask)item);

            _context.SaveChanges();
        }

        public IEnumerable<Model.Schedule> GetSchedules(int vehicleId)
        {
            return _context.Schedules.Where(v => v.Vehicle.Id == vehicleId);
        }

        public IEnumerable<Model.Task> GetTasks(int vehicleId)
        {
            return _context.Tasks.Where(v => v.Vehicle.Id == vehicleId);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
