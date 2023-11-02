using SimpleInjector;
using UniversalReports.Exchange.Report;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class ExchangeInjector
    {
        internal static Container RegisterExchangeServices(this Container container)
        {
            container.Register<Service, ServiceImp>();
            container.Register<ExcelBuilder, ExcelBuilderImp>();
            container.Register<LicenseeExcelBuilder, LicenseeExcelBuilderImp>();
            return container;
        }
    }
}
