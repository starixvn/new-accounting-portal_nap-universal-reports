using Fanex.Data.Repository;
using NSubstitute;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodFetchAsync : ApiControllerFactoryMethod
    {
        protected override IDynamicRepository CreateRepository<Model>(string fakeDatabaseFile)
        {
            var fakeData = TestDataLoader.Load<List<Model>>(fakeDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Model>(Arg.Any<ICriteria>()).Returns(fakeData);

            return repository;
        }
    }
}