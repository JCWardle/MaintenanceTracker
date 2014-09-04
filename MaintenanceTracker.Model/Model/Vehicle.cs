using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModel = MaintenanceTracker.Domain.Model.Model;

namespace MaintenanceTracker.Domain.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public virtual VehicleModel Model { get; set; }
        public string Year { get; set; }
        public int Kilometres{ get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual User User { get; set; }
    }
}
