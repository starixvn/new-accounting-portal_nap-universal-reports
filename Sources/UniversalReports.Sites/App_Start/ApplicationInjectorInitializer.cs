using Fanex.NAP.Core.Web.Session;
using SimpleInjector;

namespace UniversalReports.Sites.App_Start
{
    internal static class ApplicationInjectorInitializer
    {
        internal static void InitializeContainer(Container container)
        {
            container.Register<ICurrentSession, CurrentSession>(Lifestyle.Scoped);
        }
    }
}