using Fanex.Data.Repository;
using NSubstitute;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodGetAsync : ApiControllerFactoryMethod
    {
        protected override IDynamicRepository CreateRepository<Model>(string fakeDatabaseFile)
        {
            var fakeData = TestDataLoader.Load<Model>(fakeDatabaseFile);

            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<Model>(Arg.Any<ICriteria>()).Returns(fakeData);

            return repository;
        }
    }
}