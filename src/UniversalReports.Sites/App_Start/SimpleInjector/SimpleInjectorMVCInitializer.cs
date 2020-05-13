using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using UniversalReports.Sites.Controllers;
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
                .RegisterHouseWinLossServices()
                .RegisterNG2Services()
                .RegisterPunterAnalysisServices()
                .RegisterPlayForFunServices()
                .RegisterUpdatedUsernameAndCreditServices()
                .RegisterExchangeServices()
                .RegisterActualMemberBetServices()
                .RegisterCN88WinLossServices()
                .RegisterAbnormalBetServices();

            var homeControllerType = typeof(HomeController);
            Container.RegisterMvcControllers(homeControllerType.Assembly);

            Container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }
    }
}