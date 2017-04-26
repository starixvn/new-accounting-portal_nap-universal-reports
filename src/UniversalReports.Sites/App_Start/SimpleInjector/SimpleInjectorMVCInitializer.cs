using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using UniversalReports.Sites.SimpleInjector;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorMvcInitializer), "Initialize")]

namespace UniversalReports.Sites.SimpleInjector
{
    public static class SimpleInjectorMvcInitializer
    {
        private static readonly Container Container = new Container();

        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            Container.RegiserGlobalServices()
                .RegisterMediator()
                .RegiserAutoMapper()
                .RegisterHouseWinLossServices()
                .RegisterNG2Services()
                .RegisterPunterAnalysisServices()
                .RegisterPlayForFunServices();

            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            Container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }
    }
}