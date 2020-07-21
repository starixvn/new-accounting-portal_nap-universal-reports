using SimpleInjector;
using UniversalReports.SMAWinLoss.Filter;
using UniversalReports.SMAWinLoss.Summary;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class SMAWinLossInjector
    {
        internal static Container RegisterSMAWinLossServices(this Container container)
        {
            container.Register<FilterService, FilterServiceImp>();
            container.Register<WinLossService, WinLossServiceImp>();
            return container;
        }
    }
}