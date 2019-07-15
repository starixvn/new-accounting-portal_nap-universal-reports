using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
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
                .RegisterHouseWinLossServices()
                .RegisterNG2Services()
                .RegisterPunterAnalysisServices()
                .RegisterPlayForFunServices()
                .RegisterUpdatedUsernameAndCreditServices()
                .RegisterExchangeServices()
                .RegisterActualMemberBetServices()
                .RegisterCN88WinLossServices();

            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            Container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }
    }
}