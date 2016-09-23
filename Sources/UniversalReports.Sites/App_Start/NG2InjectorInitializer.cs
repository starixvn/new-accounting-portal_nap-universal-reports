using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using Filter = UniversalReports.NG2Statistic.Filter;

namespace UniversalReports.Sites
{
    internal static class NG2InjectorInitializer
    {
        internal static void InitializeContainer(Container container)
        {
            container.Register<Filter.Service, Filter.ServiceImp>(Lifestyle.Transient);
        }
    }
}