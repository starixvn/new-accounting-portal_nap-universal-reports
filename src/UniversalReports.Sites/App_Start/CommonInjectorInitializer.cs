using SimpleInjector;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;

namespace UniversalReports.Sites.App_Start
{
    internal static class CommonInjectorInitializer
    {
        internal static void InitializeContainer(Container container)
        {
            container.Register<BalanceUpService, BalanceUpServiceImp>(Lifestyle.Transient);
            container.Register<BalanceUpSourceChooser, BalanceUpSourceChooserImp>(Lifestyle.Transient);
        }
    }
}