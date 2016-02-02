using Fanex.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.Sites
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
            container.Register<RawService, RawServiceImp>(Lifestyle.Transient);
            container.Register<RemotingRefService, RemotingRefServiceImp>(Lifestyle.Transient);

            container.Register<CompanyWinLoss.NumberGame.Summary.Service, CompanyWinLoss.NumberGame.Summary.ServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.NumberGame.Summary.RawService, CompanyWinLoss.NumberGame.Summary.RawServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.NumberGame.Summary.CalculationService, CompanyWinLoss.NumberGame.Summary.CalculationServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.NumberGame.Summary.BalanceUpSummationService, CompanyWinLoss.NumberGame.Summary.BalanceUpSummationServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.NumberGame.MatchDetail.Service, CompanyWinLoss.NumberGame.MatchDetail.ServiceImp>(Lifestyle.Transient);

            container.Register<CompanyWinLoss.VirtualSports.Summary.Service, CompanyWinLoss.VirtualSports.Summary.ServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.VirtualSports.BetType.Service, CompanyWinLoss.VirtualSports.BetType.ServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.VirtualSports.SportsbookMatchDetail.Service, CompanyWinLoss.VirtualSports.SportsbookMatchDetail.ServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.VirtualSports.SportsbookMatchDetail.CalculationService, CompanyWinLoss.VirtualSports.SportsbookMatchDetail.CalculationServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.VirtualSports.SportsbookMatchDetail.RawService, CompanyWinLoss.VirtualSports.SportsbookMatchDetail.RawServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.VirtualSports.SportsbookMatchDetail.BalanceUpSummationService, CompanyWinLoss.VirtualSports.SportsbookMatchDetail.BalanceUpSummationServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.VirtualSports.RacingMatchDetail.Service, CompanyWinLoss.VirtualSports.RacingMatchDetail.ServiceImp>(Lifestyle.Transient);

            container.Register<SiteService, SiteServiceImp>(Lifestyle.Transient);
            container.Register<CompanyWinLoss.Products.Service, CompanyWinLoss.Products.ServiceImp>(Lifestyle.Transient);
            
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}