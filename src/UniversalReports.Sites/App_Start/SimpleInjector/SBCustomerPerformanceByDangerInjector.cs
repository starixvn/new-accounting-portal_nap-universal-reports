using SimpleInjector;
using UniversalReports.SBCustomerPerformanceByDanger.Filter;
using UniversalReports.SBCustomerPerformanceByDanger.Report;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class SBCustomerPerformanceByDangerInjector
    {
        internal static Container RegisterSBCustomerPerformanceByDangerServices(this Container container)
        {
            container.Register<FilterService, FilterServiceImp>();
            container.Register<ReportService, ReportServiceImp>();
            container.Register<ReportExcelBuilder, ReportExcelBuilderImp>();
            return container;
        }
    }
}