using System.Collections.Generic;
using System.Reflection;
using MediatR.SimpleInjector;
using SimpleInjector;

namespace UniversalReports.Exchange.Tests.DependencyInjection.SimpleInjector
{
    internal static class MediatorInjector
    {
        internal static Container RegisterMediator(this Container container)
        {
            var assemblies = GetAssemblies();
            return container.BuildMediator(assemblies);
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(ExchangeAttribute).GetTypeInfo().Assembly;
        }
    }
}
