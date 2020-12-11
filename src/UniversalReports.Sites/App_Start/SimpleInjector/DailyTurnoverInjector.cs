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

            return container;
        }
    }
}