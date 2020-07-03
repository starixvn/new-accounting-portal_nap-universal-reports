using SimpleInjector;
using UniversalReports.SBPerformance.Common;
using UniversalReports.SBPerformance.Main;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class SBPerformanceInjector
    {
        internal static Container RegisterSBPerformanceServices(this Container container)
        {
            container.Register<DataSourceChooser, DataSourceChooserImp>();
            container.Register<MainService, MainServiceImp>();
            return container;
        }
    }
}