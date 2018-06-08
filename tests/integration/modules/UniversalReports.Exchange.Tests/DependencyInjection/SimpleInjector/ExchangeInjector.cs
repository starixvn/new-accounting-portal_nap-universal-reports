using SimpleInjector;
using UniversalReports.Exchange.Report;

namespace UniversalReports.Exchange.Tests.DependencyInjection.SimpleInjector
{
    internal static class UpdatedUsernameAndCreditInjector
    {
        internal static Container RegisterExchangeServices(this Container container)
        {
            container.Register<Service, ServiceImp>();
            container.Register<ExcelBuilder, ExcelBuilderImp>();
            return container;
        }
    }
}
