using AutoMapper;
using MediatR;
using SimpleInjector;
using System.Collections.Generic;
using System.Reflection;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings.PlayForFun;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector
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
            PlayForFunAutoMapper.Initialize();
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
            yield return typeof(PlayForFunAttribute).GetTypeInfo().Assembly;
        }
    }
}
