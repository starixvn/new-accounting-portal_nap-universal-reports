using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace UniversalReports.Sites.App_Start
{
    internal class SimpleInjectorAPIConfig
    {
        internal static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            ApplicationInjectorInitializer.InitializeContainer(container);
            CompanyWinLossInjectorInitializer.InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
