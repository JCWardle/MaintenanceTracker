﻿using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using VehicleModel = MaintenanceTracker.Domain.Model.Model;

namespace MaintenanceTracker.Domain
{
    public interface IVehicleStore : IDisposable
    {
        void AddVehicle(int userId, Vehicle vehicle);
        void AddModel(VehicleModel model);
        void AddMake(Make make);
        void DeleteVehicle(int userId, int vehicle);
        IEnumerable<Vehicle> ListVehicles(string username);
    }
}
