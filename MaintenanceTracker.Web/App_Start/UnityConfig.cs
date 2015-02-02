using System;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MaintenanceTracker.Domain;

namespace MaintenanceTracker.Web.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {

            container.RegisterType<IUserStore, UserStore>();
            container.RegisterType<IMaintenanceTrackerContext, MaintenanceTrackerContext>();
            container.RegisterType<IEncryptor, Encryptor>();
            container.RegisterType<IUserProvider, UserProvider>();
            container.RegisterType<IFormsAuthenticationService, FormsAuthenticationService>();
            container.RegisterType<IVehicleStore, VehicleStore>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            container.RegisterType<IFormsAuthenticationService, FormsAuthenticationService>();
        }
    }
}
