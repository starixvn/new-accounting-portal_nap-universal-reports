using SimpleInjector;
using UniversalReports.AbnormalBet.Filter;
using UniversalReports.AbnormalBet.Report;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class AbnormalBetInjector
    {
        internal static Container RegisterAbnormalBetServices(this Container container)
        {
            container.Register<FilterService, FilterServiceImp>();
            container.Register<ReportService, ReportServiceImp>();
            container.Register<ReportExcelBuilder, ReportExcelBuilderImp>();
            return container;
        }
    }
}