using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace MaintenanceTracker.Models
{
    public class User
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Salt { get; set; }
        [Required]
        [StringLength(512)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public int ID { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(u => u.ID);
        }
    }
}
