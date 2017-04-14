using SimpleInjector;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.SportType;
using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class PunterAnalysisInjectorInitializer
    {
        internal static Container RegisterPunterAnalysisServices(this Container container)
        {
            container.Register<PunterAnalysisService, PunterAnalysisServiceImp>();
            container.Register<DateTimeService, DateTimeServiceImp>();
            container.Register<LeagueServiceFactory, LeagueServiceFactoryImp>();
            container.Register<FraudServiceWrapper, FraudServiceWrapperImp>();
            container.Register<ApplicationConfigurationService, ApplicationConfigurationServiceImp>();
            container.Register<PunterAnalysisExcelBuilder, PunterAnalysisExcelBuilderImp>();
            container.RegisterConditional<IExcelSetting, BetTypeExcelSettingFactory>(c => c.Consumer.ImplementationType == typeof(PunterAnalysis.BetType.HandlerExcel));
            container.RegisterConditional<IExcelSetting, SportTypeExcelSettingFactory>(c => c.Consumer.ImplementationType == typeof(PunterAnalysis.SportType.HandlerExcel));
            container.RegisterConditional<IExcelSetting, BetCountExcelSettingFactory>(c => c.Consumer.ImplementationType == typeof(PunterAnalysis.BetCount.HandlerExcel));
            container.RegisterConditional<IExcelSetting, SummaryExcelSettingFactory>(c => c.Consumer.ImplementationType == typeof(PunterAnalysis.Summary.HandlerExcel));
            container.RegisterConditional<IExcelSetting, LeagueExcelSettingFactory>(c => c.Consumer.ImplementationType == typeof(PunterAnalysis.League.HandlerExcel));
            container.Register<LeagueExcelBuilder, LeagueExcelBuilderImp>();
            container.Register<BetCountService, BetCountServiceImp>();

            return container;
        }
    }
}