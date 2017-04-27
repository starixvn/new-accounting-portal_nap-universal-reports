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
        private readonly Container container = new Container();

        public TController CreateController<TController, TFirstModel, TSecondModel>(string fakeFirstDatabaseFile, string fakeSecondDatabaseFile)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var fakeFirstData = TestDataLoader.Load<List<TFirstModel>>(fakeFirstDatabaseFile);
            var fakeSecondData = TestDataLoader.Load<List<TSecondModel>>(fakeSecondDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<TFirstModel>(Arg.Any<ICriteria>()).Returns(fakeFirstData);
            repository.FetchAsync<TSecondModel>(Arg.Any<ICriteria>()).Returns(fakeSecondData);

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
                   .RegisterPlayForFunServices();
            container.Verify();
        }
    }
}