using System.Web.Http;
using MaintenanceTracker.Web.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace MaintenanceTracker.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.RegisterRoutes);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.Configure();

            var container = Bootstrapper.Initialise();
            UnityConfig.RegisterTypes(container);
        }
    }
}