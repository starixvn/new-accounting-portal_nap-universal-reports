using Fanex.Caching;
using Fanex.NAP.Core.Web.Session;
using NSubstitute;
using SimpleInjector;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector
{
    internal static class GlobalInjectorInitializer
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            var currentSession = Substitute.For<ICurrentSession>();
            currentSession.UserId.Returns(1);

            container.Register<CacheService>(() => new CacheServiceImpl());
            container.Register<ICurrentSession>(() => { return currentSession; });
            container.Register<BalanceUpService, BalanceUpServiceImp>();
            container.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>();

            return container;
        }
    }
}