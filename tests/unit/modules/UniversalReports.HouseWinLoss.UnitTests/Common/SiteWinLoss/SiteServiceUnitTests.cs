using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.Common.SiteWinLoss;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.SiteWinLoss
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class SiteServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightSiteWinLoss()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("Common.SiteWinLoss.SiteService.data-1-fakeData");
            var expected = TestDataLoader.Load<SiteWinLossModel>("Common.SiteWinLoss.SiteService.data-1-expected");

            var refService = Substitute.For<RemotingRefService>();
            refService.GetMatchCode(Arg.Compat.Any<string>()).Returns("Any Name");
            var calculationService = new CalculationServiceImp(refService);
            var rawWinLossService = Substitute.For<RawWinLossService>();

            rawWinLossService.Query(Arg.Compat.Any<WinLossCriteria>()).Returns(fakeData);

            // Act
            var service = new WinLossServiceImp(rawWinLossService, calculationService);
            var result = service.Query(new TestCriteria());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}