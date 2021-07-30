using SimpleInjector;
using UniversalReports.SBPerformance.Common;
using UniversalReports.SBPerformance.Main;
using UniversalReports.SBPerformance.MarginBySite;
using UniversalReports.SBPerformance.MarginBySport;
using UniversalReports.SBPerformance.TopLosingLeague;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class SBPerformanceInjector
    {
        internal static Container RegisterSBPerformanceServices(this Container container)
        {
            container.Register<DataSourceChooser, DataSourceChooserImp>();
            container.Register<MainService, MainServiceImp>();
            container.Register<MarginBySiteService, MarginBySiteServiceImp>();
            container.Register<MarginBySportService, MarginBySportServiceImp>();
            container.Register<TopLosingLeagueService, TopLosingLeagueServiceImp>();
            return container;
        }
    }
}