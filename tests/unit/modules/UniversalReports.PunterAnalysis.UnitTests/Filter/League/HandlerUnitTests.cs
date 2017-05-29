using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Filter.League;

namespace UniversalReports.PunterAnalysis.UnitTests.Filter.League
{
    public class HandlerUnitTests
    {
        public static IEnumerable<IEnumerable<LeagueEntity>> LeagueTestCases
        {
            get
            {
                yield return new List<LeagueEntity>();
                yield return new List<LeagueEntity> { new LeagueEntity { Id = 1, Name = "Any League Name" } };
            }
        }

        [Test]
        [TestCaseSource(typeof(HandlerUnitTests), nameof(LeagueTestCases))]
        public async Task Handle_Always_ReturnsTheValueWhichIsReturnedByRepository(IEnumerable<LeagueEntity> valueFromRepository)
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueEntity>(Arg.Is<QueryCriteria>(x => x.SportId == 1 && x.FromDate == DateTime.Today && x.ToDate == DateTime.Today))
                .Returns(valueFromRepository);

            // Act
            var parameter = new HttpParameterJson { FromDate = DateTime.Today, ToDate = DateTime.Today, SportId = 1 };
            var handler = new Handler(repository);

            var result = await handler.Handle(parameter);

            Assert.That(result, IsDeeplyEqual.To(valueFromRepository));
        }
    }
}
