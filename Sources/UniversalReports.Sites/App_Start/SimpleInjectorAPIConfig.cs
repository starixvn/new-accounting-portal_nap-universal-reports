using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using UniversalReports.Sites;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SimpleInjectorApiConfig), "Initialize")]
namespace UniversalReports.Sites
{
    internal class SimpleInjectorApiConfig
    {
        internal static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            ApplicationInjectorInitializer.InitializeContainer(container);
            CommonInjectorInitializer.InitializeContainer(container);
            HouseWinLossInjectorInitializer.InitializeContainer(container);
            NG2InjectorInitializer.InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
