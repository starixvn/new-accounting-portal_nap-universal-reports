using Fanex.NAP.Core.Context;
using Fanex.NAP.Core.Service.Impl;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Context;
using Fanex.NAP.Core.Web.Session;
using SimpleInjector;

namespace UniversalReports.Sites
{
    internal static class ApplicationInjectorInitializer
    {
        internal static void InitializeContainer(Container container)
        {
            container.Register<ICurrentContext, CurrentContext>(Lifestyle.Transient);
            container.Register<IUserService, UserService>(Lifestyle.Transient);
            container.Register<IGroupService, GroupService>(Lifestyle.Transient);
            container.Register<ISiteService, SiteService>(Lifestyle.Transient);
            container.Register<ISecurityService, SecurityService>(Lifestyle.Transient);

            container.Register<ICurrentSession, CurrentSession>(Lifestyle.Transient);
        }
    }
}