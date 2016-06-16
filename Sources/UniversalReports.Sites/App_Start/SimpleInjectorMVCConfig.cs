[assembly: WebActivator.PostApplicationStartMethod(typeof(UniversalReports.Sites.App_Start.SimpleInjectorMVCConfig), "Initialize")]

namespace UniversalReports.Sites.App_Start
{
    using CompanyWinLoss.Common.BalanceUpServices;
    using Fanex.Data.Repository;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Reflection;
    using System.Web.Mvc;

    public static class SimpleInjectorMVCConfig
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IDynamicRepository, DynamicRepository>(Lifestyle.Scoped);
            container.Register<BalanceUpService, BalanceUpServiceImp>(Lifestyle.Scoped);
        }
    }
}