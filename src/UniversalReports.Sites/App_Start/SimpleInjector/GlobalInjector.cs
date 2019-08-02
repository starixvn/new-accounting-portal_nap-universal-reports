using Fanex.Caching;
using Fanex.Caching.Memory;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Context;
using Fanex.NAP.Core.Service.Impl;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Context;
using Fanex.NAP.Core.Web.Session;
using Fanex.RemotingRef;
using SimpleInjector;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.Configurations;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class GlobalInjector
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            container.Register<ICurrentContext, CurrentContext>();
            container.Register<IUserService, UserService>();
            container.Register<IGroupService, GroupService>();
            container.Register<ISiteService, SiteService>();
            container.Register<ISecurityService, SecurityService>();

            container.Register<ICurrentSession, CurrentSession>();

            container.RegisterSingleton<ICache>(() => new MemoryCache(new MemoryCacheOptions()));
            container.Register<ICacheService>(() => new CacheService());
            container.Register<BalanceUpService, BalanceUpServiceImp>();
            container.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>();

            container.Register<IDynamicRepository, DynamicRepository>();
            container.Register<ConfigurationService, ConfigurationServiceImp>();
            container.Register<IRemotingRefService, RemotingRefService>();

            return container;
        }
    }
}