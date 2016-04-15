using Fanex.Data.Repository;
using SimpleInjector;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Tests.Dependencies;
using BasicWinLoss = UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using ColumnBuilders = UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;
using GroupBetTypes = UniversalReports.CompanyWinLoss.Soccer.GroupBetType;
using MatchDetailServices = UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using NumberGameCode = UniversalReports.CompanyWinLoss.NumberGame;
using RacingCode = UniversalReports.CompanyWinLoss.Racing;
using SiteWinLoss = UniversalReports.CompanyWinLoss.Common.SiteWinLoss;
using VirtualSportsCode = UniversalReports.CompanyWinLoss.VirtualSports;

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
            Instance.Register<SiteWinLoss.SiteService, SiteWinLoss.SiteServiceImp>(Lifestyle.Transient);
            Instance.Register<SiteWinLoss.SiteGridOptionService, SiteWinLoss.SiteGridOptionServiceImp>(Lifestyle.Transient);
            Instance.Register<BasicWinLoss.BasicWinLossService, BasicWinLoss.BasicWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<BasicWinLoss.BasicGridOptionService, BasicWinLoss.BasicGridOptionServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailServices.MatchDetailBalanceUpSummationService, MatchDetailServices.MatchDetailBalanceUpSummationServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailServices.MatchDetailCalculationService, MatchDetailServices.MatchDetailCalculationServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailServices.MatchDetailRawWinLossService, MatchDetailServices.MatchDetailRawWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailServices.MatchDetailWinLossService, MatchDetailServices.MatchDetailWinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<MatchDetailServices.MatchDetailGridOptionService, MatchDetailServices.MatchDetailGridOptionServiceImp>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.GridOptionBuilder, ColumnBuilders.GridOptionBuilderImp>(Lifestyle.Transient);
            Instance.Register<ColumnBuilders.ColumnBuilder, ColumnBuilders.ColumnBuilderImp>(Lifestyle.Transient);
            Instance.Register<NumberGameCode.BetType.Service, NumberGameCode.BetType.ServiceImp>(Lifestyle.Transient);
            Instance.Register<NumberGameCode.MatchDetail.Service, NumberGameCode.MatchDetail.ServiceImp>(Lifestyle.Transient);
            Instance.Register<NumberGameCode.MatchDetail.GridOptionService, NumberGameCode.MatchDetail.GridOptionServiceImp>(Lifestyle.Transient);
            Instance.Register<CompanyWinLoss.Products.Service, CompanyWinLoss.Products.ServiceImp>(Lifestyle.Transient);
            Instance.Register<CompanyWinLoss.Products.GridOptionService, CompanyWinLoss.Products.GridOptionServiceImp>(Lifestyle.Transient);
            Instance.Register<VirtualSportsCode.RacingDetail.Service, VirtualSportsCode.RacingDetail.ServiceImp>(Lifestyle.Transient);
            Instance.Register<VirtualSportsCode.RacingDetail.GridOptionService, VirtualSportsCode.RacingDetail.GridOptionServiceImp>(Lifestyle.Transient);
            Instance.Register<RacingCode.MatchDetail.Service, RacingCode.MatchDetail.ServiceImp>(Lifestyle.Transient);
            Instance.Register<RacingCode.MatchDetail.GridOptionService, RacingCode.MatchDetail.GridOptionServiceImp>(Lifestyle.Transient);
            Instance.Register<GroupBetTypes.WinLossService, GroupBetTypes.WinLossServiceImp>(Lifestyle.Transient);
            Instance.Register<GroupBetTypes.BetTypesGridOptionService, GroupBetTypes.BetTypesGridOptionServiceImp>(Lifestyle.Transient);

            Instance.Verify();
        }

        public static Container Instance { get; private set; }
    }
}
