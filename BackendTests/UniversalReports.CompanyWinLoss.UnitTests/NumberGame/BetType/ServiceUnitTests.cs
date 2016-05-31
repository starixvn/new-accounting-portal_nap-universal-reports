using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.NumberGame.BetType;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;
using CommonModels = UniversalReports.CompanyWinLoss.Common.Models;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.NumberGame.BetType
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
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
