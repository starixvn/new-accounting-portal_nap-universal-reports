using SimpleInjector;
using UniversalReports.PlayForFun.Core;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector
{
    internal static class PlayForFunInjector
    {
        internal static Container RegisterPlayForFunServices(this Container container)
        {
            container.Register<PlayForFunService, PlayForFunServiceImp>();
            container.Register<PlayForFunExcelBuilder, PlayForFunExcelBuilderImp>();

            return container;
        }
    }
}