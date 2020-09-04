using SimpleInjector;
using UniversalReports.Core.Configurations;

namespace UniversalReports.SMAWinLoss.Tests.DependencyInjection.SimpleInjector
{
    internal static class GlobalInjector
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            container.Register<ConfigurationService, ConfigurationServiceImp>();

            return container;
        }
    }
}