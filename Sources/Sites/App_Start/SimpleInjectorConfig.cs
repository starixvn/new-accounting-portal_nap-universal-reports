using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace NAP.Reports.CompanyWinLoss.Sites
{
    public class SimpleInjectorConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IBalanceUpService, BalanceUpService>(Lifestyle.Transient);
            container.Register<IBalanceUpSourceChooser, BalanceUpSourceChooser>(Lifestyle.Transient);
            container.Register<ICalculationService, CalculationService>(Lifestyle.Transient);
            container.Register<IProductWinLossService, ProductWinLossService>(Lifestyle.Transient);
            container.Register<ISportsbookWinLossService, SportsbookWinLossService>(Lifestyle.Transient);
            container.Register<IMainReportService, MainReportService>(Lifestyle.Transient);
            container.Register<IDynamicRepository, DynamicRepository>(Lifestyle.Transient);
            container.Register<IConfiguration, Configuration>(Lifestyle.Transient);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}