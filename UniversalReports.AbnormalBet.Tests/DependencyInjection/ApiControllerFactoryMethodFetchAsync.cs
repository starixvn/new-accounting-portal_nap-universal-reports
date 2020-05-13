using Fanex.Data.Repository;
using NSubstitute;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Collections.Generic;
using UniversalReports.AbnormalBet.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.AbnormalBet.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodFetchAsync
    {
        private readonly Container container;

        public ApiControllerFactoryMethodFetchAsync(Container container)
        {
            this.container = container;
        }

        public TController CreateController<TController, TModel, TModelSecond>(string fakeDatabaseFile, string fakeSecondDatabaseFile)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var fakeData = TestDataLoader.Load<List<TModel>>(fakeDatabaseFile);
            var fakeSecondData = TestDataLoader.Load<TModelSecond>(fakeSecondDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<TModel>(Arg.Compat.Any<ICriteria>()).Returns(fakeData);
            repository.GetAsync<TModelSecond>(Arg.Compat.Any<ICriteria>()).Returns(fakeSecondData);

            RegisterDependency(repository);

            return (TController)container.GetInstance(typeof(TController));
        }

        private void RegisterDependency(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                   .RegisterMediator()
                   .RegisterAbnormalBetServices();
            container.Verify();
        }
    }
}
