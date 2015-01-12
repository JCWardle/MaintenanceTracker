using System.ComponentModel.DataAnnotations;

namespace MaintenanceTracker.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MinLength(3)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string Email {get; set;}
    }
}