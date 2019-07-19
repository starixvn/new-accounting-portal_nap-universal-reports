using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.OtherSports.NewCricket;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;

namespace UniversalReports.HouseWinLoss.UnitTests.OtherSports.NewCricket
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightResult()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("OtherSports.NewCricket.Service.data-1-fakeData");
            var expected = TestDataLoader.Load<WinLossModel>("OtherSports.NewCricket.Service.data-1-expected");

            // Act
            var refService = Substitute.For<RemotingRefService>();
            refService.GetMatchCode(Arg.Compat.Any<string>()).Returns("Any Name");
            var calculationService = new CalculationServiceImp(refService);
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Compat.Any<WinLossCriteria>()).Returns(fakeData);

            var service = new WinLossServiceImp(rawWinLossService, calculationService);
            var result = service.Query(new TestCriteria());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}