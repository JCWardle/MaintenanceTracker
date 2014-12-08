using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain
{
    public class MaintenanceStore : IMaintenanceStore, IDisposable
    {
        IMaintenanceTrackerContext _context;
        public MaintenanceStore(IMaintenanceTrackerContext context)
        {
            _context = context;
        }

        public void AddSchedule(int vehicleId, Model.Schedule schedule)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle == null)
                throw new ArgumentException("Invalid Vehicle");

            schedule.Vehicle = vehicle;

            _context.Schedules.Add(schedule);
        }

        public void AddTask(int vehicleId, Model.Task task)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle == null)
                throw new ArgumentException("Invalid Vehicle");

            task.Vehicle = vehicle;

            _context.Tasks.Add(task);
        }

        public IEnumerable<Model.Schedule> GetSchedules(int vehicleId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Task> GetTasks(int vehicleId, int page, int pageSize)
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
            if (disposing)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
