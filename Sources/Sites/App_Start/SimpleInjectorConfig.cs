using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Services;
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
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IDynamicRepository, DynamicRepository>(Lifestyle.Transient);
            container.Register<IBalanceUpService, BalanceUpService>(Lifestyle.Transient);
            container.Register<IBalanceUpSourceChooser, BalanceUpSourceChooser>(Lifestyle.Transient);
            container.Register<ICalculationService, CalculationService>(Lifestyle.Transient);
            container.Register<IRawWinLossService, RawWinLossService>(Lifestyle.Transient);
            container.Register<IProductWinLossService, ProductWinLossService>(Lifestyle.Transient);
            container.Register<INumberGameBetTypeSummaryWinLossService, NumberGameBetTypeSummaryWinLossService>(Lifestyle.Transient);
            container.Register<INumberGameMatchDetailWinLossService, NumberGameMatchDetailWinLossService>(Lifestyle.Transient);
            container.Register<ISiteWinLossService, SiteWinLossService>(Lifestyle.Transient);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}