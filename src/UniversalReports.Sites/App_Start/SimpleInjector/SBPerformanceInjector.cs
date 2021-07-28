using SimpleInjector;
using UniversalReports.SBPerformance.Common;
using UniversalReports.SBPerformance.League;
using UniversalReports.SBPerformance.Main;
using UniversalReports.SBPerformance.Site;
using UniversalReports.SBPerformance.Sport;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class SBPerformanceInjector
    {
        internal static Container RegisterSBPerformanceServices(this Container container)
        {
            container.Register<DataSourceChooser, DataSourceChooserImp>();
            container.Register<MainService, MainServiceImp>();
            container.Register<SiteService, SiteServiceImp>();
            container.Register<LeagueService, LeagueServiceImp>();
            container.Register<SportService, SportServiceImp>();
            return container;
        }
    }
}