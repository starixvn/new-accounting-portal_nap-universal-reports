using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using UniversalReports.Sites.SimpleInjector;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SimpleInjectorApiConfig), "Initialize")]

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class SimpleInjectorApiConfig
    {
        private static Container container = new Container();

        internal static void Initialize()
        {
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.RegiserGlobalServices()
                .RegisterHouseWinLossServices()
                .RegisterNG2Services()
                .RegisterPunterAnalysisServices()
                .RegisterMediator();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}