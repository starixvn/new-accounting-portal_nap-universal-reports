using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Soccer.SumBetType;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;
using CalculationServiceImp = UniversalReports.CompanyWinLoss.Soccer.BetType.CalculationServiceImp;

namespace UniversalReports.CompanyWinLoss.UnitTests.Soccer.SumBetType
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTest
    {
        [Test]
        public void Query_ReturnRightResult()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-1-fakeData");
            var expected = TestDataLoader.Load<WinLossModel>("data-1-expected");

            // Act
            var calculatorService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            var service = new WinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert           
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
