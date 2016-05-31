using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.BasicWinLoss
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class BasicWinLossServiceUnitTest
    {
        [Test]
        public void Query_ReturnRightBasicWinLossSummary()
        {
            // Arrange   
            var expected = TestDataLoader.Load<BasicWinLossModel>("data-1-expected");
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-1-fakeData");

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
