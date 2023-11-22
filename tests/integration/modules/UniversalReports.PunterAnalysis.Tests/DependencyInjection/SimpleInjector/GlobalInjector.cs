using Fanex.Caching;
using Fanex.Caching.Memory;
using Fanex.NAP.Core.Web.Session;
using NSubstitute;
using SimpleInjector;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector
{
    using BalanceUpServices;
    using Configurations;

    internal static class GlobalInjector
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            var currentSession = Substitute.For<ICurrentSession>();
            currentSession.UserId.Returns(1);

            container.RegisterSingleton<ICache>(() => new MemoryCache(new MemoryCacheOptions()));
            container.Register<ICacheService>(() => new CacheService());
            container.Register(() => currentSession);
            container.Register<BalanceUpService, BalanceUpServiceImp>();
            container.Register<ConfigurationService, ConfigurationServiceImp>();

            return container;
        }
    }
}