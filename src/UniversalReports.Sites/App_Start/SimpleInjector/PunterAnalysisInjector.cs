using Olympus.FPSAPI.Client;
using SimpleInjector;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.BetTypeGroup;
using UniversalReports.PunterAnalysis.Game;
using UniversalReports.PunterAnalysis.GameBetType;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.SportType;
using UniversalReports.PunterAnalysis.Summary;




namespace UniversalReports.Sites.SimpleInjector
{
    internal static class PunterAnalysisInjector
    {
        internal static Container RegisterPunterAnalysisServices(this Container container)
        {
            container.Register<PunterAnalysisService, PunterAnalysisServiceImp>();
            container.Register<DateTimeService, DateTimeServiceImp>();
            container.Register<LeagueServiceFactory, LeagueServiceFactoryImp>();
            container.Register<FraudServiceWrapper, FraudServiceWrapperImp>();
            container.Register<PunterAnalysisExcelBuilder, PunterAnalysisExcelBuilderImp>();
            container.RegisterConditional<ExcelSettingFactory, BetTypeExcelSettingFactory>(
                c => c.Consumer.ImplementationType == typeof(PunterAnalysis.BetType.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, SportTypeExcelSettingFactory>(
                c => c.Consumer.ImplementationType == typeof(PunterAnalysis.SportType.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, BetCountExcelSettingFactory>(
                c => c.Consumer.ImplementationType == typeof(PunterAnalysis.BetCount.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, SummaryExcelSettingFactory>(
                c => c.Consumer.ImplementationType == typeof(PunterAnalysis.Summary.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, LeagueExcelSettingFactory>(
                c => c.Consumer.ImplementationType == typeof(PunterAnalysis.League.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, AssociatedAccountExcelSettingFactory>(
                c => c.Consumer.ImplementationType == typeof(PunterAnalysis.AssociatedAccount.HandlerExcel));
            container.Register<LeagueExcelBuilder, LeagueExcelBuilderImp>();
            container.Register<BetCountService, BetCountServiceImp>();
            container.Register<AssociatedFacade, AssociatedFacadeImp>();
            container.RegisterConditional<ExcelSettingFactory, GameExcelSettingFactory>(
               c => c.Consumer.ImplementationType == typeof(PunterAnalysis.Game.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, GameBetTypeExcelSettingFactory>(
              c => c.Consumer.ImplementationType == typeof(PunterAnalysis.GameBetType.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, BetTypeGroupExcelSettingFactory>(
              c => c.Consumer.ImplementationType == typeof(PunterAnalysis.BetTypeGroup.HandlerExcel));
            return container;
        }
    }
}