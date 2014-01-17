using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Models
{
    public class RegisterModel : ErrorModel
    {
        [Required]
        [StringLength (50)]
        [Display(Name = "Username")]
        public string Username {get; set;}
        [Required]
        [Display (Name = "Password")]
        [DataType (DataType.Password)]
        [StringLength (200)]
        public string Password { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}