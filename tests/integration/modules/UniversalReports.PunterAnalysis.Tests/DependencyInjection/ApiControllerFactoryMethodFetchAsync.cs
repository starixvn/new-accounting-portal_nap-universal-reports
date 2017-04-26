using Fanex.Data.Repository;
using NSubstitute;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodFetchAsync : IDisposable
    {
        private readonly Container container = new Container();

        public TController CreateController<TController, TModel>(string fakeDatabaseFile)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var repository = CreateRepository<TModel>(fakeDatabaseFile);
            RegisterDependency(repository);

            return (TController)container.GetInstance(typeof(TController));
        }

        public void Dispose()
        {
            container.Dispose();
        }

        private void RegisterDependency(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                    .RegisterAutoMapper()
                    .RegisterMediator()
                    .RegisterPunterAnalysisServices();
            container.Verify();
        }

        private IDynamicRepository CreateRepository<TModel>(string fakeDatabaseFile)
        {
            var fakeData = TestDataLoader.Load<List<TModel>>(fakeDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<TModel>(Arg.Any<ICriteria>()).Returns(fakeData);

            return repository;
        }
    }
}