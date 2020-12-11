using SimpleInjector;
using UniversalReports.DailyTurnoverComparison;
using UniversalReports.DailyTurnoverComparison.Service;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class DailyTurnoverInjector
    {
        internal static Container RegisterDailyTurnoverServices(this Container container)
        {
            container.Register<DataService, DataServiceImp>();
            container.Register<ExcelService, ExcelServiceImp>();
            container.Register<DateTimeService, DateTimeServiceImp>();
            container.Register<DBService, DBServiceImp>();

            return container;
        }
    }
}