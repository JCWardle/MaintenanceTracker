using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceTracker.Web.ViewModels
{
    public class HomeViewModel
    {
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }
    }
}