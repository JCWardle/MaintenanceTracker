using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaintenanceTracker.Domain
{
    public interface IMaintenanceStore : IDisposable
    {
        void AddSchedule(int vehicleId, Schedule schedule);
        void AddTask(int vehicleId, Task task);
        IEnumerable<Schedule> GetSchedules(int vehicleId, int page, int pageSize);
        IEnumerable<Task> GetTasks(int vehicleId, int page, int pageSize);
    }
}