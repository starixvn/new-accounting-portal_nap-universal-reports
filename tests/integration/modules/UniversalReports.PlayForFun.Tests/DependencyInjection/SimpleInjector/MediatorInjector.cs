using System.Collections.Generic;
using System.Reflection;
using MediatR.SimpleInjector;
using SimpleInjector;
using UniversalReports.PlayForFun.Core;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector
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
            yield return typeof(PlayForFunAttribute).GetTypeInfo().Assembly;
        }
    }
}