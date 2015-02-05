using System.Collections.Generic;
using VehicleModel = MaintenanceTracker.Domain.Model.Model;

namespace MaintenanceTracker.Domain.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public virtual VehicleModel Model { get; set; }
        public string Year { get; set; }
        public int Kilometers { get; set; }
        public virtual ICollection<WorkItem> WorkItems { get; set; }
        public virtual User User { get; set; }
        public virtual Make Make { get; set; }
    }
}
