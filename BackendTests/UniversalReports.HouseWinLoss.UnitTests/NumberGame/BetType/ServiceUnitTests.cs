using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.NumberGame.BetType;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using CommonModels = UniversalReports.HouseWinLoss.Common.Models;
using CommonServices = UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.UnitTests.NumberGame.BetType
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightNumberGameBetTypeWinLossSummary()
        {
            // Arrange   
            var fakeData = TestDataLoader.Load<List<CommonModels.RawWinLoss>>("data-1-fakeData");
            var expected = TestDataLoader.Load<WinLossModel>("data-1-expected");

            var calculationService = new CommonServices.CalculationServiceImp();
            var rawWinLossService = Substitute.For<CommonServices.RawWinLossService>();

            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
