using MediatR.SimpleInjector;
using SimpleInjector;
using System.Collections.Generic;
using System.Reflection;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector
{
    public static class MediatorInjector
    {
        public static Container RegisterMediator(this Container container)
        {
            var assemblies = GetAssemblies();
            return container.BuildMediator(assemblies);
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(PunterAnalysisAttribute).GetTypeInfo().Assembly;
        }
    }
}
