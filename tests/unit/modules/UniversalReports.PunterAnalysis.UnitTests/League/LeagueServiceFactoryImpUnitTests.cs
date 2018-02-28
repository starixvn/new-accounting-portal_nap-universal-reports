using System;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.Shared;

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
            var dateTimeService = Substitute.For<DateTimeService>();
            var factory = new LeagueServiceFactoryImp(repository, dateTimeService);
            var service = factory.CreateLeagueService(periodType);

            return service.GetType().Name;
        }

        [Test]
        [TestCase(0)]
        [TestCase(6)]
        public void CreateLeagueService_InvalidPeriodType_ThrowsNotImplementedException(int periodType)
        {
            var repository = Substitute.For<IDynamicRepository>();
            var dateTimeService = Substitute.For<DateTimeService>();
            var factory = new LeagueServiceFactoryImp(repository, dateTimeService);

            Assert.That(() => factory.CreateLeagueService(periodType), Throws.TypeOf<NotImplementedException>());
        }
    }
}