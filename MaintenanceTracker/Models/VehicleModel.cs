using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class VehicleModel
    {
        [Required]
        [Display (Name = "Make")]
        public string Make { get; set; }
        [Required]
        [Display (Name = "Model")]
        public string Model { get; set; }
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        [Display (Name = "Year")]
        public string Year { get; set; }
        [Display (Name = "Registration")]
        public string Registration { get; set; }
        public int Id { get; set; }

        public static VehicleModel ConvertVehicle(Vehicle v)
        {
            return new VehicleModel
            {
                Make = v.Make,
                Model = v.Model,
                Registration = v.Registration,
                Year = v.Year.Year.ToString(),
                Id = v.VehicleId
            };
        }
    }
}