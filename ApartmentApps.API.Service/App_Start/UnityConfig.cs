using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace ApartmentApps.API.Service
{
    public static class IocExtensions
    {
        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }

        public static void BindInSingletonScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new ContainerControlledLifetimeManager());
        }
    }
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			Container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

          //  DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        public static UnityContainer Container { get; set; }
    }

    
}