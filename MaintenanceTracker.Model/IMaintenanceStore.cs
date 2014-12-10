using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaintenanceTracker.Domain
{
    public interface IMaintenanceStore : IDisposable
    {
        void AddWorkItem(int vehicleId, WorkItem item);
        IEnumerable<Schedule> GetSchedules(int vehicleId);
        IEnumerable<Task> GetTasks(int vehicleId);
    }
}