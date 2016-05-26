using Fanex.Data.Repository;
using SimpleInjector;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Tests.Dependencies;
using BasicWinLoss = UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;
using Decorator = UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using MatchDetail = UniversalReports.CompanyWinLoss.Common.MatchDetail;
using MatchDetailByCode = UniversalReports.CompanyWinLoss.Common.MatchDetailByCode;
using NumberGames = UniversalReports.CompanyWinLoss.NumberGame;
using SiteWinLoss = UniversalReports.CompanyWinLoss.Common.SiteWinLoss;
using Soccers = UniversalReports.CompanyWinLoss.Soccer;

namespace UniversalReports.CompanyWinLoss.Tests
{
    public class SimpleInjectorContainer
    {
        static SimpleInjectorContainer()
        {
            Instance = new Container();

            Instance.Register<CommonServices.RemotingRefService, RemotingRefServiceFake>(Lifestyle.Transient);

            Instance.Register<IDynamicRepository, DynamicRepository>(Lifestyle.Transient);
            Instance.Register<BalanceUpService, BalanceUpServiceImp>(Lifestyle.Transient);
            Instance.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>(Lifestyle.Transient);
            Instance.Register<BalanceUpSummationService, BalanceUpSummationServiceImp>(Lifestyle.Transient);
            Instance.Register<CommonServices.CalculationService, CommonServices.CalculationServiceImp>(Lifestyle.Transient);
            Instance.Register<CommonServices.RawWinLossService, CommonServices.RawWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<SiteWinLoss.WinLossService, SiteWinLoss.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<SiteWinLoss.GridOptionsBuilder, SiteWinLoss.GridOptionsBuilderImp>(Lifestyle.Transient);
            Instance.Register<BasicWinLoss.BasicWinLossService, BasicWinLoss.BasicWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<BasicWinLoss.BasicGridOptionsBuilder, BasicWinLoss.BasicGridOptionsBuilderImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.BalanceUpSummationService, MatchDetail.BalanceUpSummationServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.CalculationService, MatchDetail.CalculationServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.RawWinLossService, MatchDetail.RawWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.WinLossService, MatchDetail.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.GridOptionsBuilder, MatchDetail.GridOptionsBuilderImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailByCode.WinLossService, MatchDetailByCode.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailByCode.GridOptionsBuilder, MatchDetailByCode.GridOptionsBuilderImp>(Lifestyle.Transient);
            Instance.Register<NumberGames.BetType.Service, NumberGames.BetType.ServiceImp>(Lifestyle.Transient);
            Instance.Register<CompanyWinLoss.Products.Service, CompanyWinLoss.Products.ServiceImp>(Lifestyle.Transient);
            Instance.Register<CompanyWinLoss.Products.GridOptionsBuilder, CompanyWinLoss.Products.GridOptionsBuilderImp>(Lifestyle.Transient);
            Instance.Register<Soccers.GroupBetType.WinLossService, Soccers.GroupBetType.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<Soccers.SumBetType.WinLossService, Soccers.SumBetType.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<Soccers.GroupBetType.GridOptionsBuilder, Soccers.GroupBetType.GridOptionsBuilderImp>(Lifestyle.Transient);
            Instance.Register<Soccers.SumBetType.GridOptionsBuilder, Soccers.SumBetType.GridOptionsBuilderImp>(Lifestyle.Transient);
            Instance.Register<Soccers.BetType.CalculationService, Soccers.BetType.CalculationServiceImp>(Lifestyle.Transient);

            Instance.Register<Decorator.GridOptionColumnDecorator, Decorator.GridOptionColumnDecoratorBasic>(Lifestyle.Transient);
            Instance.Register<Decorator.GridOptionColumnDecoratorBasic, Decorator.GridOptionColumnDecoratorBasic>(Lifestyle.Transient);
            Instance.Register<Decorator.GridOptionColumnDecoratorExtraPT, Decorator.GridOptionColumnDecoratorExtraPT>(Lifestyle.Transient);
            Instance.Register<Decorator.GridOptionColumnDecoratorFull, Decorator.GridOptionColumnDecoratorFull>(Lifestyle.Transient);
            Instance.Register<Decorator.GridOptionColumnDecoratorVirtual, Decorator.GridOptionColumnDecoratorVirtual>(Lifestyle.Transient);
            Instance.Register<Decorator.GridOptionColumnRemoval, Decorator.GridOptionColumnRemovalImp>(Lifestyle.Transient);
            Instance.Register<Decorator.MatchGridOptionColumnDecorator, Decorator.MatchGridOptionColumnDecoratorByCode>(Lifestyle.Transient);
            Instance.Register<Decorator.MatchGridOptionColumnDecoratorByCode, Decorator.MatchGridOptionColumnDecoratorByCode>(Lifestyle.Transient);
            Instance.Register<Decorator.MatchGridOptionColumnDecoratorFull, Decorator.MatchGridOptionColumnDecoratorFull>(Lifestyle.Transient);
            Instance.Register<Decorator.MatchGridOptionColumnDecoratorBasic, Decorator.MatchGridOptionColumnDecoratorBasic>(Lifestyle.Transient);

            // This is an extension method from the integration package.
            Instance.Verify();
        }

        public static Container Instance { get; }
    }
}
