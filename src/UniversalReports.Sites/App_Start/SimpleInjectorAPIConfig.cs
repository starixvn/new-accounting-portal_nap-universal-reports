using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using UniversalReports.Sites.App_Start;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SimpleInjectorApiConfig), "Initialize")]

namespace UniversalReports.Sites.App_Start
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