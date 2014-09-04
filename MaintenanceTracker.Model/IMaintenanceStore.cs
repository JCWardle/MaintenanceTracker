using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaintenanceTracker.Model
{
    public interface IMaintenanceStore
    {
        public void AddSchedule(int vehicleId, MaintenanceSchedule schedule);
        public void AddTask(int vehicleId, Task task);
        public IEnumerable<MaintenanceSchedule> GetSchedules(int vehicleId);
        public IEnumerable<Task> GetTasks(int vehicleId);
    }
}