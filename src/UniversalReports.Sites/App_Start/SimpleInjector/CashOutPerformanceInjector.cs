using SimpleInjector;
using UniversalReports.CashOutPerformance.Services;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class CashOutPerformanceInjector
    {
        internal static Container RegisterCashOutPerformanceServices(this Container container)
        {
            container.Register<CashOutPerformanceService, CashOutPerformanceServiceImp>();
            container.Register<TicketsExcelBuilder, TicketsExcelBuilderImp>();
            return container;
        }
    }
}