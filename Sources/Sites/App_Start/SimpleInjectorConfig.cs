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
            container.Register<BalanceUpService, BalanceUpServiceImp>(Lifestyle.Transient);
            container.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>(Lifestyle.Transient);
            container.Register<CalculationService, CalculationServiceImp>(Lifestyle.Transient);
            container.Register<BalanceUpSummationService, BalanceUpSummationServiceImp>(Lifestyle.Transient);
            container.Register<RawWinLossService, RawWinLossServiceImp>(Lifestyle.Transient);
            container.Register<ProductWinLossService, ProductWinLossServiceImp>(Lifestyle.Transient);
            container.Register<NumberGameBetTypeSummaryWinLossService, NumberGameBetTypeSummaryWinLossServiceImp>(Lifestyle.Transient);
            container.Register<NumberGameMatchDetailWinLossService, NumberGameMatchDetailWinLossServiceImp>(Lifestyle.Transient);
            container.Register<SiteWinLossService, SiteWinLossServiceImp>(Lifestyle.Transient);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}