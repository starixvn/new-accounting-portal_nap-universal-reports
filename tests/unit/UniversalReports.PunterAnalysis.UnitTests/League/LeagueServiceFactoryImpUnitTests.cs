using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using UniversalReports.PunterAnalysis.League;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class LeagueServiceFactoryImpUnitTests
    {
        [Test]
        [TestCase(1, ExpectedResult = "LeagueServiceByMonthImp")]
        [TestCase(2, ExpectedResult = "LeagueServiceByWeekImp")]
        [TestCase(3, ExpectedResult = "LeagueServiceByMonthImp")]
        [TestCase(4, ExpectedResult = "LeagueServiceByMonthImp")]
        [TestCase(5, ExpectedResult = "LeagueServiceByMonthImp")]
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
