using Fanex.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;
using NumberGameMatchDetail = UniversalReports.CompanyWinLoss.NumberGame.MatchDetail;
using NumberGameSummary = UniversalReports.CompanyWinLoss.NumberGame.Summary;
using RacingMatchDetail = UniversalReports.CompanyWinLoss.VirtualSports.RacingMatchDetail;
using SportsbookMatchDetail = UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail;

namespace UniversalReports.Sites
{
    public static class SimpleInjectorConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void Register()
        {
            using (var container = new Container())
            {
                Register(container);
            }
        }

        private static void Register(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IDynamicRepository, DynamicRepository>(Lifestyle.Transient);
            container.Register<CommonServices.BalanceUpService, CommonServices.BalanceUpServiceImp>(Lifestyle.Transient);
            container.Register<CommonServices.BalanceUpSourceChooser, CommonServices.BalanceUpSourceChooserImp>(Lifestyle.Transient);
            container.Register<CommonServices.BalanceUpSummationService, CommonServices.BalanceUpSummationServiceImp>(Lifestyle.Transient);
            container.Register<CommonServices.CalculationService, CommonServices.CalculationServiceImp>(Lifestyle.Transient);
            container.Register<CommonServices.RawService, CommonServices.RawServiceImp>(Lifestyle.Transient);
            container.Register<CommonServices.RemotingRefService, CommonServices.RemotingRefServiceImp>(Lifestyle.Transient);
            container.Register<CommonServices.SiteService, CommonServices.SiteServiceImp>(Lifestyle.Transient);
            container.Register<CommonServices.BetTypeService, CommonServices.BetTypeServiceImp>(Lifestyle.Transient);
            container.Register<CommonServices.SportTypeService, CommonServices.SportTypeServiceImp>(Lifestyle.Transient);
            container.Register<NumberGameSummary.BalanceUpSummationService, NumberGameSummary.BalanceUpSummationServiceImp>(Lifestyle.Transient);
            container.Register<NumberGameSummary.CalculationService, NumberGameSummary.CalculationServiceImp>(Lifestyle.Transient);
            container.Register<NumberGameSummary.RawService, NumberGameSummary.RawServiceImp>(Lifestyle.Transient);
            container.Register<NumberGameSummary.Service, NumberGameSummary.ServiceImp>(Lifestyle.Transient);
            container.Register<NumberGameMatchDetail.Service, NumberGameMatchDetail.ServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.Products.Service, CompanyWinLoss.Products.ServiceImp>(Lifestyle.Transient);
            container.Register<RacingMatchDetail.Service, RacingMatchDetail.ServiceImp>(Lifestyle.Transient);
            container.Register<SportsbookMatchDetail.BalanceUpSummationService, SportsbookMatchDetail.BalanceUpSummationServiceImp>(Lifestyle.Transient);
            container.Register<SportsbookMatchDetail.CalculationService, SportsbookMatchDetail.CalculationServiceImp>(Lifestyle.Transient);
            container.Register<SportsbookMatchDetail.RawService, SportsbookMatchDetail.RawServiceImp>(Lifestyle.Transient);
            container.Register<SportsbookMatchDetail.Service, SportsbookMatchDetail.ServiceImp>(Lifestyle.Transient);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}