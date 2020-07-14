using SimpleInjector;
using UniversalReports.AbnormalBet.Filter;
using UniversalReports.AbnormalBet.IpLocation;
using UniversalReports.AbnormalBet.Report;

namespace UniversalReports.AbnormalBet.Tests.DependencyInjection.SimpleInjector
{
    internal static class AbnormalBetInjector
    {
        internal static Container RegisterAbnormalBetServices(this Container container)
        {
            container.Register<FilterService, FilterServiceImp>();
            container.Register<ReportService, ReportServiceImp>();
            container.Register<ReportExcelBuilder, ReportExcelBuilderImp>();
            container.Register<LocationService, LocationServiceImp>();
            return container;
        }
    }
}
