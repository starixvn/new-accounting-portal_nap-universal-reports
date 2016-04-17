using Fanex.Data.Repository;
using SimpleInjector;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Tests.Dependencies;
using BasicWinLoss = UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using ColumnBuilders = UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;
using GroupBetTypes = UniversalReports.CompanyWinLoss.Soccer.GroupBetType;
using MatchDetail = UniversalReports.CompanyWinLoss.Common.MatchDetail;
using MatchDetailByCode = UniversalReports.CompanyWinLoss.Common.MatchDetailByCode;
using NumberGameCode = UniversalReports.CompanyWinLoss.NumberGame;
using SiteWinLoss = UniversalReports.CompanyWinLoss.Common.SiteWinLoss;

namespace UniversalReports.CompanyWinLoss.Tests
{
    public class SimpleInjectorContainer
    {
        static SimpleInjectorContainer()
        {
            Instance = new Container();
            Instance.Register<IDynamicRepository, DynamicRepository>(Lifestyle.Transient);
            Instance.Register<BalanceUpService, BalanceUpServiceImp>(Lifestyle.Transient);
            Instance.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>(Lifestyle.Transient);
            Instance.Register<BalanceUpSummationService, BalanceUpSummationServiceImp>(Lifestyle.Transient);
            Instance.Register<CommonServices.CalculationService, CommonServices.CalculationServiceImp>(Lifestyle.Transient);
            Instance.Register<CommonServices.RawWinLossService, CommonServices.RawWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<CommonServices.RemotingRefService, RemotingRefServiceFake>(Lifestyle.Transient);
            Instance.Register<SiteWinLoss.WinLossService, SiteWinLoss.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<SiteWinLoss.GridOptionBuilder, SiteWinLoss.GridOptionBuilderImp>(Lifestyle.Transient);
            Instance.Register<BasicWinLoss.BasicWinLossService, BasicWinLoss.BasicWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<BasicWinLoss.BasicGridOptionBuilder, BasicWinLoss.BasicGridOptionBuilderImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.BalanceUpSummationService, MatchDetail.BalanceUpSummationServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.CalculationService, MatchDetail.CalculationServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.RawWinLossService, MatchDetail.RawWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.WinLossService, MatchDetail.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetail.GridOptionBuilder, MatchDetail.GridOptionBuilderImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailByCode.GridOptionBuilder, MatchDetailByCode.GridOptionBuilderImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailByCode.WinLossService, MatchDetailByCode.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.GridOptionColumnDecoratorBasic, ColumnBuilders.GridOptionColumnDecoratorBasic>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.GridOptionColumnDecoratorFull, ColumnBuilders.GridOptionColumnDecoratorFull>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.GridOptionColumnDecoratorVirtual, ColumnBuilders.GridOptionColumnDecoratorVirtual>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.GridOptionColumnDecoratorExtraPT, ColumnBuilders.GridOptionColumnDecoratorExtraPT>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.MatchGridOptionColumnDecoratorBasic, ColumnBuilders.MatchGridOptionColumnDecoratorBasic>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.MatchGridOptionColumnDecoratorFull, ColumnBuilders.MatchGridOptionColumnDecoratorFull>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.GridOptionColumnRemoval, ColumnBuilders.GridOptionColumnRemovalImp>(Lifestyle.Transient);
            Instance.Register<NumberGameCode.BetType.Service, NumberGameCode.BetType.ServiceImp>(Lifestyle.Transient);
            Instance.Register<CompanyWinLoss.Products.Service, CompanyWinLoss.Products.ServiceImp>(Lifestyle.Transient);
            Instance.Register<CompanyWinLoss.Products.GridOptionBuilder, CompanyWinLoss.Products.GridOptionBuilderImp>(Lifestyle.Transient);
            Instance.Register<GroupBetTypes.WinLossService, GroupBetTypes.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<GroupBetTypes.GridOptionBuilder, GroupBetTypes.GridOptionBuilderImp>(Lifestyle.Transient);

            Instance.Verify();
        }

        public static Container Instance { get; }
    }
}
