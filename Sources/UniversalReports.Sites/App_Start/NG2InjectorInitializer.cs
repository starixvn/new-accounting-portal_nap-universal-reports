using SimpleInjector;
using UniversalReports.NG2Statistic.Common;
using BettypeReport = UniversalReports.NG2Statistic.Bettype;
using DailyReport = UniversalReports.NG2Statistic.Daily;
using Filter = UniversalReports.NG2Statistic.Filter;
using GrandTotalReport = UniversalReports.NG2Statistic.GrandTotal;
using UserNameReport = UniversalReports.NG2Statistic.UserName;

namespace UniversalReports.Sites
{
    internal static class NG2InjectorInitializer
    {
        internal static void InitializeContainer(Container container)
        {
            container.Register<GridOptionHeaderColumn, GridOptionHeaderColumnImp>(Lifestyle.Transient);
            container.Register<Filter.Service, Filter.ServiceImp>(Lifestyle.Transient);            
            container.Register<DailyReport.GridOptionsBuilder, DailyReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<DailyReport.DailyService, DailyReport.DailyServiceImp>(Lifestyle.Transient);            
            container.Register<GrandTotalReport.GrandTotalService, GrandTotalReport.GrandTotalServiceImp>(Lifestyle.Transient);
            container.Register<GrandTotalReport.GridOptionsBuilder, GrandTotalReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<GrandTotalReport.GridOptionHeaderColumn, GrandTotalReport.GridOptionHeaderColumnImp>(Lifestyle.Transient);            
            container.Register<UserNameReport.UserNameService, UserNameReport.UserNameServiceImp>(Lifestyle.Transient);
            container.Register<UserNameReport.GridOptionsBuilder, UserNameReport.GridOptionsBuilderImp>(Lifestyle.Transient);
            container.Register<UserNameReport.GridOptionHeaderColumn, UserNameReport.GridOptionHeaderColumnImp>(Lifestyle.Transient);            
            container.Register<BettypeReport.BettypeService, BettypeReport.BettypeServiceImp>(Lifestyle.Transient);
            container.Register<BettypeReport.GridOptionsBuilder, BettypeReport.GridOptionsBuilderImp>(Lifestyle.Transient);
        }
    }
}