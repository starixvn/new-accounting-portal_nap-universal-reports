using System.Collections.Generic;
using Fanex.Data.Repository;
using NSubstitute;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using UniversalReports.UpdatedUsernameCredit.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.UpdatedUsernameCredit.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodFetchAsync
    {
        private readonly Container container;

        public ApiControllerFactoryMethodFetchAsync(Container container)
        {
            this.container = container;
        }

        public TController CreateController<TController, TModel>(string fakeDatabaseFile)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var fakeData = TestDataLoader.Load<List<TModel>>(fakeDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<TModel>(Arg.Compat.Any<ICriteria>()).Returns(fakeData);

            RegisterDependency(repository);

            return (TController)container.GetInstance(typeof(TController));
        }

        private void RegisterDependency(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                   .RegisterMediator()
                   .RegisterUpdatedUsernameAndCreditServices();
            container.Verify();
        }
    }
}
