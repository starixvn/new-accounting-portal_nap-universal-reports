using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Filter.SportTypeLeague;

namespace UniversalReports.PunterAnalysis.UnitTests.Filter.SportTypeLeague
{
    public class HandlerUnitTests
    {
        public static IEnumerable<IEnumerable<SportTypeLeagueEntity>> SportTypeLeagueTestCases
        {
            get
            {
                yield return new List<SportTypeLeagueEntity>();
                yield return new List<SportTypeLeagueEntity> { CreateSportTypeLeagueEntity() };
            }
        }

        [Test]
        [TestCaseSource(typeof(HandlerUnitTests), nameof(SportTypeLeagueTestCases))]
        public async Task Handle_Always_ReturnsTheValueWhichIsReturnedByRepository(IEnumerable<SportTypeLeagueEntity> valueFromRepository)
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SportTypeLeagueEntity>(Arg.Any<QueryCriteria>())
                .Returns(valueFromRepository);

            // Act
            var parameter = new HttpParameterJson();
            var handler = new Handler(repository);

            var result = await handler.Handle(parameter);
            Assert.That(result, IsDeeplyEqual.To(valueFromRepository));
        }

        private static SportTypeLeagueEntity CreateSportTypeLeagueEntity()
        {
            return new SportTypeLeagueEntity
            {
                LeagueId = 1,
                LeagueName = "Any League Name"
            };
        }
    }
}
