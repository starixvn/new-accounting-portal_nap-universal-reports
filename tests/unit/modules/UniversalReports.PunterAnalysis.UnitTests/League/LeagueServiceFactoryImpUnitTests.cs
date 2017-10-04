using System;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.League;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class LeagueServiceFactoryImpUnitTests
    {
        [Test]
        [TestCase(1, ExpectedResult = "LeagueServiceByMonth")]
        [TestCase(2, ExpectedResult = "LeagueServiceByWeek")]
        [TestCase(3, ExpectedResult = "LeagueServiceByMonth")]
        [TestCase(4, ExpectedResult = "LeagueServiceByMonth")]
        [TestCase(5, ExpectedResult = "LeagueServiceByMonth")]
        public string CreateLeagueService_Test(int periodType)
        {
            var repository = Substitute.For<IDynamicRepository>();
            var factory = new LeagueServiceFactoryImp(repository);
            var service = factory.CreateLeagueService(periodType);

            return service.GetType().Name;
        }

        [Test]
        [TestCase(0)]
        [TestCase(6)]
        public void CreateLeagueService_InvalidPeriodType_ThrowsNotImplementedException(int periodType)
        {
            var repository = Substitute.For<IDynamicRepository>();
            var factory = new LeagueServiceFactoryImp(repository);

            Assert.That(() => factory.CreateLeagueService(periodType), Throws.TypeOf<NotImplementedException>());
        }
    }
}