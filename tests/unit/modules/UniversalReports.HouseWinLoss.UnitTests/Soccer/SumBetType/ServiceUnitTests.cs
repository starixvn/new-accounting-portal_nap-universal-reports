using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.Soccer.SumBetType;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using BaseCalculationServiceImp = UniversalReports.HouseWinLoss.Soccer.BaseService.BaseCalculationServiceImp;

namespace UniversalReports.HouseWinLoss.UnitTests.Soccer.SumBetType
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
            var expected = TestDataLoader.Load<SumBetTypeWinLossModel>("data-1-expected");

            // Act
            var calculatorService = new BaseCalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            var service = new SumBetTypeWinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
