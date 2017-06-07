using MediatR.SimpleInjector;
using SimpleInjector;
using System.Collections.Generic;
using System.Reflection;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.Sites.SimpleInjector
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
            yield return typeof(PlayForFunAttribute).GetTypeInfo().Assembly;
        }
    }
}