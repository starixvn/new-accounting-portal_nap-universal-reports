using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.BasicWinLoss
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class BasicWinLossServiceUnitTest
    {
        [Test]
        public void Query_ReturnRightBasicWinLossSummary()
        {
            // Arrange   
            var expected = TestDataLoader.Load<BasicWinLossModel>("data-1-expected");
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("data-1-fakeData");

            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new BasicWinLossServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
