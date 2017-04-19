using Fanex.Caching;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Context;
using Fanex.NAP.Core.Service.Impl;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Context;
using Fanex.NAP.Core.Web.Session;
using SimpleInjector;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.Configurations;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class GlobalInjectorInitializer
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            container.Register<ICurrentContext, CurrentContext>();
            container.Register<IUserService, UserService>();
            container.Register<IGroupService, GroupService>();
            container.Register<ISiteService, SiteService>();
            container.Register<ISecurityService, SecurityService>();

            container.Register<ICurrentSession, CurrentSession>();

            container.Register<CacheService>(() => new CacheServiceImpl());
            container.Register<BalanceUpService, BalanceUpServiceImp>();
            container.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>();

            container.Register<IDynamicRepository, DynamicRepository>();
            container.Register<ApplicationConfigurationService, ApplicationConfigurationServiceImp>();

            return container;
        }
    }
}