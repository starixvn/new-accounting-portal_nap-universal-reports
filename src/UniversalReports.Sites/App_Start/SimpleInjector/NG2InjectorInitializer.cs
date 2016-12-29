using SimpleInjector;
using UniversalReports.NG2Statistics.BaseServices;
using BettypeReport = UniversalReports.NG2Statistics.Bettype;
using DailyReport = UniversalReports.NG2Statistics.Daily;
using Filter = UniversalReports.NG2Statistics.Filter;
using GrandTotalReport = UniversalReports.NG2Statistics.GrandTotal;
using UserNameReport = UniversalReports.NG2Statistics.UserName;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class NG2InjectorInitializer
    {
        internal static Container RegisterNG2Services(this Container container)
        {
            container.Register<BaseGridOptionHeaderColumn, BaseGridOptionHeaderColumnImp>(Lifestyle.Transient);
            container.Register<Filter.Service, Filter.ServiceImp>(Lifestyle.Transient);
            container.Register<DailyReport.GridOptionsBuilder, DailyReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<DailyReport.DailyService, DailyReport.DailyServiceImp>(Lifestyle.Transient);
            container.Register<GrandTotalReport.GrandTotalService, GrandTotalReport.GrandTotalServiceImp>(Lifestyle.Transient);
            container.Register<GrandTotalReport.GridOptionsBuilder, GrandTotalReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<GrandTotalReport.GridOptionHeaderColumn, GrandTotalReport.GridOptionHeaderColumnImp>(Lifestyle.Transient);
            container.Register<UserNameReport.UserNameService, UserNameReport.UserNameServiceImp>(Lifestyle.Transient);
            container.Register<UserNameReport.GridOptionsBuilder, UserNameReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<UserNameReport.GridOptionHeaderColumn, UserNameReport.GridOptionHeaderColumnImp>(Lifestyle.Transient);
            container.Register<BettypeReport.Repository, BettypeReport.RepositoryImp>(Lifestyle.Transient);
            container.Register<BettypeReport.BettypeService, BettypeReport.BettypeServiceImp>(Lifestyle.Transient);
            container.Register<BettypeReport.GridOptionsBuilder, BettypeReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<BettypeReport.SortingService, BettypeReport.SortingServiceImp>(Lifestyle.Transient);

            return container;
        }
    }
}