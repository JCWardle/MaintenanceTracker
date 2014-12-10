using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MaintenanceTracker
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public static class MvcContainer
        {
            public static IUnityContainer Container { get; set; }
        }

        protected override IController GetControllerInstance(RequestContext context, Type type)
        {
            if (type != null)
                return MvcContainer.Container.Resolve(type) as IController;
            return null;
        }
    }
}