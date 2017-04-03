using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Filter.AvailableDatabase;

namespace UniversalReports.PunterAnalysis.UnitTests.AvailableDatabase
{
    public class HandlerUnitTests
    {
        [Test]
        [TestCase(true, ExpectedResult = true)]
        [TestCase(false, ExpectedResult = false)]
        public async Task<bool> Handle_Always_ReturnsTheValueWhichIsReturnedByRepository(bool valueFromRepository)
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<bool>(Arg.Any<QueryCriteria>()).Returns(valueFromRepository);

            // Act
            var parameter = new HttpParameterJson();
            var handler = new Handler(repository);

            return await handler.Handle(parameter);
        }
    }
}
