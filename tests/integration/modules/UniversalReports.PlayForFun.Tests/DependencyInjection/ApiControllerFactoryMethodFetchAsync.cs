using Fanex.Data.Repository;
using NSubstitute;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodFetchAsync : IDisposable
    {
        private Container container = new Container();

        public Controller CreateController<Controller, Model>(string fakeDatabaseFile)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var repository = CreateRepository<Model>(fakeDatabaseFile);
            RegisterDependency(repository);

            return (Controller)container.GetInstance(typeof(Controller));
        }

        public Controller CreateController<Controller, FirstModel, SecondModel>(string fakeFirstDatabaseFile, string fakeSecondDatabaseFile)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var fakeFirstData = TestDataLoader.Load<List<FirstModel>>(fakeFirstDatabaseFile);
            var fakeSecondData = TestDataLoader.Load<List<SecondModel>>(fakeSecondDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FirstModel>(Arg.Any<ICriteria>()).Returns(fakeFirstData);
            repository.FetchAsync<SecondModel>(Arg.Any<ICriteria>()).Returns(fakeSecondData);

            RegisterDependency(repository);

            return (Controller)container.GetInstance(typeof(Controller));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                container.Dispose();
            }
        }

        private void RegisterDependency(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                   .RegisterAutoMapper()
                   .RegisterMediator()
                   .RegisterPlayForFunServices();
            container.Verify();
        }

        private IDynamicRepository CreateRepository<Model>(string fakeDatabaseFile)
        {
            var fakeData = TestDataLoader.Load<List<Model>>(fakeDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Model>(Arg.Any<ICriteria>()).Returns(fakeData);

            return repository;
        }
    }
}