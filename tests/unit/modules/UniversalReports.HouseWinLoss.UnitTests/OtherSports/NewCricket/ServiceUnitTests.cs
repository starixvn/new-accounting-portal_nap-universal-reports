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
            var calculateService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            var service = new WinLossServiceImp(rawWinLossService, calculateService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            ComparisonAssert.AreEqual(result, expected);
        }
    }
}