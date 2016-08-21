using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using System.Web.Http;
using DataServices.IServices;
using DataServices.Services;
using Resolver;

namespace CAD_API
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();            
            //container.RegisterType<IBusinessUnitService, BusinessUnitService>().RegisterType<DBBusinessUnitService>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserService, UserService>().RegisterType<DBUserService>(new HierarchicalLifetimeManager());

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "CAD-API.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "Data Services.dll");
        }
    }
}