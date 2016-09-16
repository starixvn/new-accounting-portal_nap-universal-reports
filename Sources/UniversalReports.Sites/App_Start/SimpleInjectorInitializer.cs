[assembly: WebActivator.PostApplicationStartMethod(typeof(UniversalReports.Sites.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace UniversalReports.Sites.App_Start
{
    using Fanex.Repository;
    using HouseWinLoss.Common.BalanceUpServices;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Reflection;
    using System.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
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
            container.Register<SimpleRepository, SimpleRepositoryImp>(Lifestyle.Scoped);
            container.Register<BalanceUpService, BalanceUpServiceImp>(Lifestyle.Scoped);
        }
    }
}