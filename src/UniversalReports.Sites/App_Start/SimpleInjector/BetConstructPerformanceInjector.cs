using SimpleInjector;
using UniversalReports.BetConstructPerformance.Services;

namespace UniversalReports.Sites.App_Start.SimpleInjector
{
    public static class BetConstructPerformanceInjector
    {
        public static Container RegisterBetConstructPerformanceServices(this Container container)
        {
            container.Register<BetConstructPerformanceService, BetConstructPerformanceServiceImp>();
            container.Register<ExcelBuilderService, ExcelBuilderServiceImp>();
            return container;
        }
    }
}