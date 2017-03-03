using SimpleInjector;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class PunterAnalysisInjectorInitializer
    {
        internal static Container RegisterPunterAnalysisServices(this Container container)
        {
            container.Register<PunterAnalysisService, PunterAnalysisServiceImp>();

            return container;
        }
    }
}