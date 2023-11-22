using SimpleInjector;

namespace UniversalReports.AbnormalBet.Tests.DependencyInjection.SimpleInjector
{
    using Configurations;

    internal static class GlobalInjector
    {
        internal static Container RegiserGlobalServices(this Container container)
        {
            container.Register<ConfigurationService, ConfigurationServiceImp>();

            return container;
        }
    }
}
