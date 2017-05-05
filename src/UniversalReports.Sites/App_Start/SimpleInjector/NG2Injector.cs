using SimpleInjector;
using UniversalReports.NG2Statistics.BaseServices;
using BettypeReport = UniversalReports.NG2Statistics.Bettype;
using DailyReport = UniversalReports.NG2Statistics.Daily;
using Filter = UniversalReports.NG2Statistics.Filter;
using GrandTotalReport = UniversalReports.NG2Statistics.GrandTotal;
using UserNameReport = UniversalReports.NG2Statistics.UserName;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class NG2Injector
    {
        internal static Container RegisterNG2Services(this Container container)
        {
            container.Register<BaseGridOptionHeaderColumn, BaseGridOptionHeaderColumnImp>();
            container.Register<Filter.Service, Filter.ServiceImp>();
            container.Register<DailyReport.GridOptionsBuilder, DailyReport.GridOptionsBuilderImp>();
            container.Register<DailyReport.DailyService, DailyReport.DailyServiceImp>();
            container.Register<GrandTotalReport.GrandTotalService, GrandTotalReport.GrandTotalServiceImp>();
            container.Register<GrandTotalReport.GridOptionsBuilder, GrandTotalReport.GridOptionsBuilderImp>();
            container.Register<GrandTotalReport.GridOptionHeaderColumn, GrandTotalReport.GridOptionHeaderColumnImp>();
            container.Register<UserNameReport.UserNameService, UserNameReport.UserNameServiceImp>();
            container.Register<UserNameReport.GridOptionsBuilder, UserNameReport.GridOptionsBuilderImp>();
            container.Register<UserNameReport.GridOptionHeaderColumn, UserNameReport.GridOptionHeaderColumnImp>();
            container.Register<BettypeReport.Repository, BettypeReport.RepositoryImp>();
            container.Register<BettypeReport.BettypeService, BettypeReport.BettypeServiceImp>();
            container.Register<BettypeReport.GridOptionsBuilder, BettypeReport.GridOptionsBuilderImp>();
            container.Register<BettypeReport.SortingService, BettypeReport.SortingServiceImp>();

            return container;
        }
    }
}