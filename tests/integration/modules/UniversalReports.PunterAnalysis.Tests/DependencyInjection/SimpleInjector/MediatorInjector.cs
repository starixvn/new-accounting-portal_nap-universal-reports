using AutoMapper;
using MediatR;
using SimpleInjector;
using System.Collections.Generic;
using System.Reflection;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings.PunterAnalysis;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector
{
    public static class MediatorInjector
    {
        public static Container RegisterMediator(this Container container)
        {
            IntializeMapper();
            RegisterAssemblies(container);

            return container;
        }

        private static void IntializeMapper()
        {
            PunterAnalysisAutoMapper.Initialize();
        }

        private static void RegisterAssemblies(Container container)
        {
            var assemblies = GetAssemblies();
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.Register(typeof(IAsyncRequestHandler<,>), assemblies);
            container.Register(typeof(ICancellableAsyncRequestHandler<>), assemblies);
            container.RegisterCollection(typeof(INotificationHandler<>), assemblies);
            container.RegisterCollection(typeof(IAsyncNotificationHandler<>), assemblies);
            container.RegisterCollection(typeof(ICancellableAsyncNotificationHandler<>), assemblies);
            container.RegisterCollection(typeof(IPipelineBehavior<,>), assemblies);

            container.Register(() => Mapper.Instance);
            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(IPunterAnalysis).GetTypeInfo().Assembly;
        }
    }
}
