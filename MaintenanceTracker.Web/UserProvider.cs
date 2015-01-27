using System.Web;

namespace MaintenanceTracker.Web
{
    public class UserProvider : IUserProvider
    {
        public string CurrentUserName()
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }
}