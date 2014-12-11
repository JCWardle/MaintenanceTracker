using MaintenanceTracker.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MaintenanceTracker.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(typeof(ControllerFactory));

            var container = Bootstrapper.Initialise();
            UnityConfig.RegisterTypes(container);
            ControllerFactory.MvcContainer.Container = container;
        }
    }
}
