using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;
using UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.RacingDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightMatchDetailWinLoss()
        {
            // Arrange   
            var expectedMatchDetailWinLoss = CreateExpectedMatchDetailWinLoss();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreTwoMatchDetailWinLossEqual(expectedMatchDetailWinLoss, result);
            Assert.True(equal);
        }

        private WinLossModel CreateExpectedMatchDetailWinLoss()
        {
            var expectedMatches = CreateExpectedMatches();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new WinLossModel
            {
                Matches = expectedMatches,
                Total = expectedGrandTotal
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            return new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "MatchCode 1", 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "MatchCode 2", 110, 120, 11, 550, 660, 990, 1100)
            };
        }

        private List<WinLoss> CreateExpectedMatches()
        {
            return new List<WinLoss>
            {
                WinLossFactory.CreateWinLoss(0, "MatchCode 1", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000),
                WinLossFactory.CreateWinLoss(0, "MatchCode 2", 110, 120, 11, 550, 660, -110, 990, 1100, 550m / 990, 660m / 1100)
            };
        }

        private WinLoss CreateExpectedGrandTotal()
        {
            return WinLossFactory.CreateWinLoss(0, "Total", 210, 230, 21, 1050, 1260, -210, 1890, 2100, 1050m / 1890, 1260m / 2100);
        }

        private bool AreTwoMatchDetailWinLossEqual(WinLossModel first, WinLossModel second)
        {
            return WinLossComparision.AreTwoWinLossEqual(first.Total, second.Total) 
                && WinLossComparision.AreTwoWinLossListEqual(first.Matches, second.Matches);
        }
    }
}
