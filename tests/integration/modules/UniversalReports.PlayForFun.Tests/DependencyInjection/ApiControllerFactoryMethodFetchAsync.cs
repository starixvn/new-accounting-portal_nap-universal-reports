using System.Collections.Generic;
using Fanex.Data.Repository;
using NSubstitute;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodFetchAsync
    {
        private readonly Container container;

        public ApiControllerFactoryMethodFetchAsync(Container container)
        {
            this.container = container;
        }

        public TController CreateController<TController, TFirstModel, TSecondModel>(string fakeFirstDatabaseFile, string fakeSecondDatabaseFile)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var fakeFirstData = TestDataLoader.Load<List<TFirstModel>>(fakeFirstDatabaseFile);
            var fakeSecondData = TestDataLoader.Load<List<TSecondModel>>(fakeSecondDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<TFirstModel>(Arg.Compat.Any<ICriteria>()).Returns(fakeFirstData);
            repository.FetchAsync<TSecondModel>(Arg.Compat.Any<ICriteria>()).Returns(fakeSecondData);

            RegisterDependency(repository);

            return (TController)container.GetInstance(typeof(TController));
        }

        private void RegisterDependency(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                   .RegisterMediator()
                   .RegisterPlayForFunServices();
            container.Verify();
        }
    }
}