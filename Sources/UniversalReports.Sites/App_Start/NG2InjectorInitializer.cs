using SimpleInjector;
using UniversalReports.NG2Statistic.Data;
using DailyReport = UniversalReports.NG2Statistic.Data.Daily;
using Filter = UniversalReports.NG2Statistic.Filter;
using GrandTotalReport = UniversalReports.NG2Statistic.Data.GrandTotal;

namespace UniversalReports.Sites
{
    internal static class NG2InjectorInitializer
    {
        internal static void InitializeContainer(Container container)
        {
            container.Register<GridOptionHeaderColumn, GridOptionHeaderColumnImp>(Lifestyle.Transient);
            container.Register<Filter.Service, Filter.ServiceImp>(Lifestyle.Transient);
            container.Register<DailyReport.Repository, DailyReport.RepositoryImp>(Lifestyle.Transient);
            container.Register<DailyReport.GridOptionsBuilder, DailyReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<DailyReport.DailyService, DailyReport.DailyServiceImp>(Lifestyle.Transient);            
            container.Register<GrandTotalReport.Repository, GrandTotalReport.RepositoryImp>(Lifestyle.Transient);
            container.Register<GrandTotalReport.GrandTotalService, GrandTotalReport.GrandTotalServiceImp>(Lifestyle.Transient);
            container.Register<GrandTotalReport.GridOptionsBuilder, GrandTotalReport.GridOptionsBuilderImp>(Lifestyle.Transient);
        }
    }
}