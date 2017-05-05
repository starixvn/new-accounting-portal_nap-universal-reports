using SimpleInjector;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector
{
    internal static class PlayForFunInjector
    {
        internal static Container RegisterPlayForFunServices(this Container container)
        {
            container.Register<PlayForFunService, PlayForFunServiceImp>();
            container.Register<ExcelBuilder, ExcelBuilderImp>();

            return container;
        }
    }
}