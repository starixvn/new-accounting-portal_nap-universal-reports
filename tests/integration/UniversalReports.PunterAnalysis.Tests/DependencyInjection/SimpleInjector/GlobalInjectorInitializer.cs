using Fanex.Caching;
using Fanex.NAP.Core.Web.Session;
using SimpleInjector;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;
using UniversalReports.PunterAnalysis.Tests.Mocks;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector
{
    internal static class GlobalInjectorInitializer
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            container.Register<CacheService>(() => new CacheServiceImpl());
            container.Register<ICurrentSession, CurrentSessionMock>();
            container.Register<BalanceUpService, BalanceUpServiceImp>();
            container.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>();

            return container;
        }
    }
}