using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
