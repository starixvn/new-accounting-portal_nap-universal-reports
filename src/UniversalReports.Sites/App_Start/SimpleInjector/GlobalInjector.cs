using Fanex.Caching;
using Fanex.Caching.Memory;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Context;
using Fanex.NAP.Core.Service.Impl;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Context;
using Fanex.NAP.Core.Web.Session;
using Fanex.RemotingRef;
using ONEbook.UM.Configurations;
using ONEbook.UM.Helpers;
using ONEbook.UM.NETFramework;
using ONEbook.UM.Services;
using ONEbook.UM.Transport;
using SimpleInjector;

namespace UniversalReports.Sites.SimpleInjector
{
    using BalanceUpServices;
    using Configurations;

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
            container.Register<BalanceUpService, BalanceUpServiceImp>();

            container.Register<IDynamicRepository, DynamicRepository>();
            container.Register<ConfigurationService, ConfigurationServiceImp>();
            container.Register<IRemotingRefService, RemotingRefService>();
            container.RegisterInstance(new UMClientConfiguration().Initialize());
            container.RegisterInstance<ICacheService>(new CacheService());
            container.RegisterSingleton<IUMCacheService, UMCacheService>();
            container.RegisterSingleton<IPHelper, IPHelperImpl>();
            container.RegisterSingleton<IUMRestClient, UMRestClient>();
            container.RegisterSingleton<IHttpContextHelper, HttpContextHelper>();
            container.RegisterSingleton<IMaintenanceService, MaintenanceService>();


            return container;
        }
    }
}