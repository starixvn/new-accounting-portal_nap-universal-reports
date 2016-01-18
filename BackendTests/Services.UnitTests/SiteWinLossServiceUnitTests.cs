using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.Main
{
    public class SiteWinLossServiceUnitTests
    {
        [Test]
        [Category("ServiceUnitTests")]
        public void Query_ReturnRightSiteWinLoss()
        {
            // Arrange   
            var expectedSiteWinLoss = CreateExpectedSiteWinLoss();
            var calculationService = new CalculationService();
            var rawWinLossService = Substitute.For<IRawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new SiteWinLossService(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = WinLossComparision.AreTwoSiteWinLossEqual(expectedSiteWinLoss, result);
            Assert.True(equal);
        }

        private SiteWinLoss CreateExpectedSiteWinLoss()
        {
            var siteWinLosses = new List<WinLoss>
            {
                WinLossFactory.CreateWinLoss(0, "Site 1", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m),
                WinLossFactory.CreateWinLoss(0, "Site 2", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m),
                WinLossFactory.CreateWinLoss(0, "Site 3", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m),
                WinLossFactory.CreateWinLoss(0, "Site 4", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m)
            };

            var total = WinLossFactory.CreateWinLoss(0, "Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 5m / 9, 0.6m);

            return new SiteWinLoss
            {
                Sites = siteWinLosses,
                Total = total
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            return new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "Site 1", false, 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "Site 2", false, 110, 120, 11, 550, 660, 990, 1100),
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "Site 3", false, 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "Site 4", false, 110, 120, 11, 550, 660, 990, 1100)
            };
        }
    }
}
