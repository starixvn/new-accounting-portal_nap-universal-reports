using SimpleInjector;
using UniversalReports.NG2Statistic.Data;
using DailyReport = UniversalReports.NG2Statistic.Data.Daily;
using Filter = UniversalReports.NG2Statistic.Filter;

namespace UniversalReports.Sites
{
    internal static class NG2InjectorInitializer
    {
        internal static void InitializeContainer(Container container)
        {
            container.Register<Filter.Service, Filter.ServiceImp>(Lifestyle.Transient);
            container.Register<DailyReport.GridOptionsBuilder, DailyReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<DailyReport.DailyService, DailyReport.DailyServiceImp>(Lifestyle.Transient);
            container.Register<GridOptionHeaderColumn, GridOptionHeaderColumnImp>(Lifestyle.Transient);
        }
    }
}