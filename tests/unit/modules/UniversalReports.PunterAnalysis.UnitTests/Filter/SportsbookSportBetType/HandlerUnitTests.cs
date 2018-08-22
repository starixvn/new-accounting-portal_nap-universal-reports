using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType;

namespace UniversalReports.PunterAnalysis.UnitTests.Filter.SportsbookSportBetType
{
    public class HandlerUnitTests
    {
        public static IEnumerable<IEnumerable<SportsbookSportBetTypeEntity>> SportsbookSportBetTypeTestCases
        {
            get
            {
                yield return new List<SportsbookSportBetTypeEntity>();
                yield return new List<SportsbookSportBetTypeEntity> { CreateProductSportBetTypeEntity() };
            }
        }

        [Test]
        [TestCaseSource(typeof(HandlerUnitTests), nameof(SportsbookSportBetTypeTestCases))]
        public async Task Handle_Always_ReturnsTheValueWhichIsReturnedByRepository(IEnumerable<SportsbookSportBetTypeEntity> valueFromRepository)
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SportsbookSportBetTypeEntity>(Arg.Any<QueryCriteria>())
                .Returns(valueFromRepository);

            // Act
            var parameter = new HttpParameterJson();
            var handler = new Handler(repository);

            var result = await handler.Handle(parameter, new CancellationToken());
            Assert.That(result, IsDeeplyEqual.To(valueFromRepository));
        }

        private static SportsbookSportBetTypeEntity CreateProductSportBetTypeEntity()
        {
            return new SportsbookSportBetTypeEntity
            {
                SportType = 1,
                SportName = "Any Sport Name",
                BetTypeName = "Any Bet Type Name",
                CombinationId = 1
            };
        }
    }
}