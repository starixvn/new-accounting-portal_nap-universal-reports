using SimpleInjector;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Services;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class CashOutPerformanceInjector
    {
        internal static Container RegisterCashOutPerformanceServices(this Container container)
        {
            container.Register<CashOutPerformanceService, CashOutPerformanceServiceImp>();
            container.Register<ModelsHelperService, ModelsHelperServiceImp>();
            container.Register<TicketsExcelBuilder<SportLevelExcelModel>, TicketsExcelBuilderImp<SportLevelExcelModel>>();
            container.Register<TicketsExcelBuilder<EventStatusLevelExcelModel>, TicketsExcelBuilderImp<EventStatusLevelExcelModel>>();
            container.Register<TicketsExcelBuilder<BetTypeLevelExcelModel>, TicketsExcelBuilderImp<BetTypeLevelExcelModel>>();
            container.Register<TicketsExcelBuilder<SimpleBetTypeLevelExcelModel>, TicketsExcelBuilderImp<SimpleBetTypeLevelExcelModel>>();
            container.Register<TicketsExcelBuilder<MatchDetailLevelExcelModel>, TicketsExcelBuilderImp<MatchDetailLevelExcelModel>>();
            return container;
        }
    }
}