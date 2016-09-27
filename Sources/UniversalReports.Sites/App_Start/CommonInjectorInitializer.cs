using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using UniversalReports.Common.BalanceUpServices;

namespace UniversalReports.Sites
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