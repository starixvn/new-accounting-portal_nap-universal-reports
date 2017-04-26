using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using UniversalReports.Sites.SimpleInjector;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SimpleInjectorApiConfig), "Initialize")]

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class SimpleInjectorApiConfig
    {
        private static readonly Container Container = new Container();

        internal static void Initialize()
        {
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.RegiserGlobalServices()
                .RegisterMediator()
                .RegiserAutoMapper()
                .RegisterHouseWinLossServices()
                .RegisterNG2Services()
                .RegisterPunterAnalysisServices()
                .RegisterPlayForFunServices();

            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            Container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }
    }
}