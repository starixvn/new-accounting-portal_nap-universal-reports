using Fanex.Data.Repository;
using NSubstitute;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using UniversalReports.SMAWinLoss.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.SMAWinLoss.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodFetchAsync
    {
        private readonly Container container;

        public ApiControllerFactoryMethodFetchAsync(Container container)
        {
            this.container = container;
        }

        public TController CreateController<TController, TModel>(string fakeBodyDatabaseFile, string fakeTotalDataBaseFile, int numberUsers)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var fakeBodyData = TestDataLoader.Load<IEnumerable<TModel>>(fakeBodyDatabaseFile);
            var fakeTotalData = TestDataLoader.Load<IEnumerable<TModel>>(fakeTotalDataBaseFile);

            var fakeData = ValueTuple.Create<IEnumerable<TModel>, IEnumerable<TModel>, IEnumerable<int>>(
                fakeBodyData,
                fakeTotalData,
                new List<int> { numberUsers });

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchMultipleAsync<TModel, TModel, int>(Arg.Compat.Any<ICriteria>()).Returns(fakeData);

            RegisterDependency(repository);

            return (TController)container.GetInstance(typeof(TController));
        }

        private void RegisterDependency(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                   .RegisterMediator()
                   .RegisterSMAWinLossServices();
            container.Verify();
        }
    }
}