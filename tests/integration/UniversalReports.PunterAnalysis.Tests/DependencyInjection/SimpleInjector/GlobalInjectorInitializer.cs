using Fanex.Caching;
using SimpleInjector;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector
{
    internal static class GlobalInjectorInitializer
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            container.Register<CacheService>(() => new CacheServiceImpl());
            container.Register<BalanceUpService, BalanceUpServiceImp>();
            container.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>();

            return container;
        }
    }
}