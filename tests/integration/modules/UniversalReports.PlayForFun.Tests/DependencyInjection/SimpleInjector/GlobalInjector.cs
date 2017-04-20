using Fanex.Caching;
using Fanex.NAP.Core.Web.Session;
using NSubstitute;
using SimpleInjector;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.Configurations;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector
{
    internal static class GlobalInjector
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            var currentSession = Substitute.For<ICurrentSession>();
            currentSession.UserId.Returns(1);

            container.Register<CacheService>(() => new CacheServiceImpl());
            container.Register(() => currentSession);
            container.Register<BalanceUpService, BalanceUpServiceImp>();
            container.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>();

            container.Register<ApplicationConfigurationService, ApplicationConfigurationServiceImp>();

            return container;
        }
    }
}