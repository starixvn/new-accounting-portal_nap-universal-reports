using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.Soccer.GroupBetType;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using CalculationServiceImp = UniversalReports.HouseWinLoss.Soccer.BaseService.CalculationServiceImp;

namespace UniversalReports.HouseWinLoss.UnitTests.Soccer.GroupBetType
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightResult()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-1-fakeData");
            var expected = TestDataLoader.Load<WinLossModel>("data-1-expected");

            var calculatorService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act
            var service = new WinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
