using SimpleInjector;
using UniversalReports.SMAWinLoss.Filter;
using UniversalReports.SMAWinLoss.Summary;
using UniversalReports.SMAWinLoss.VirtualRate;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class SMAWinLossInjector
    {
        internal static Container RegisterSMAWinLossServices(this Container container)
        {
            container.Register<FilterService, FilterServiceImp>();
            container.Register<WinLossService, WinLossServiceImp>();
            container.Register<VirtualRateService, VirtualRateServiceImp>();
            return container;
        }
    }
}