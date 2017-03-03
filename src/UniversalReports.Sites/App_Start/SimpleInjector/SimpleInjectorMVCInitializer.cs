using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using UniversalReports.Sites.SimpleInjector;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorMVCInitializer), "Initialize")]

namespace UniversalReports.Sites.SimpleInjector
{
    public static class SimpleInjectorMVCInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegiserGlobalServices()
            .RegisterHouseWinLossServices()
            .RegisterNG2Services()
            .RegisterPunterAnalysisServices()
            .RegisterMediator();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}