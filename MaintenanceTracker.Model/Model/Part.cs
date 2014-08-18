using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain.Model
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public decimal Cost { get; set; }
        public string Retailer { get; set; }
        public string Reciept { get; set; }
    }
}
