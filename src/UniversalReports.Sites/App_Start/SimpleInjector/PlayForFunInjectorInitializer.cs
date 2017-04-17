using SimpleInjector;
using UniversalReports.PlayForFun.Core;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class PlayForFunInjectorInitializer
    {
        internal static Container RegisterPlayForFunServices(this Container container)
        {
            container.Register<PlayForFunService, PlayForFunServiceImp>();
            container.Register<PlayForFunExcelBuilder, PlayForFunExcelBuilderImp>();

            return container;
        }
    }
}