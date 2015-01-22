using System;
using System.Web;
using System.Web.Security;
namespace MaintenanceTracker.Web
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SetAuthCookie(string username, bool remember)
        {
            var authTicket = new FormsAuthenticationTicket(
            1,                             
            username,                     
            DateTime.Now,                  
            DateTime.Now.AddMinutes(20),   
            remember, 
            ""                  
            );

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }
    }
}