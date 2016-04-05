using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class SiteServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightSiteWinLoss()
        {
            // Arrange   
            var expectedSiteWinLoss = CreateExpectedSiteWinLoss();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new SiteServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = WinLossComparision.AreTwoSiteWinLossEqual(expectedSiteWinLoss, result);
            Assert.True(equal);
        }

        private SiteWinLossModel CreateExpectedSiteWinLoss()
        {
            var siteWinLosses = new List<WinLoss>
            {
                WinLossFactory.CreateWinLoss(0, "Site 1", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000),
                WinLossFactory.CreateWinLoss(0, "Site 2", 110, 120, 11, 550, 660, -110, 990, 1100, 550m / 990, 660m / 1100),
                WinLossFactory.CreateWinLoss(0, "Site 3", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000),
                WinLossFactory.CreateWinLoss(0, "Site 4", 110, 120, 11, 550, 660, -110, 990, 1100, 550m / 990, 660m / 1100)
            };

            var total = WinLossFactory.CreateWinLoss(0, "Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 2100m / 3780, 2520m / 4200);

            return new SiteWinLossModel
            {
                Sites = siteWinLosses,
                Total = total
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            return new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "Site 1", 100, 110, 10, 500, 600, 100, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "Site 2", 110, 120, 11, 550, 660, 100, 990, 1100),
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "Site 3", 100, 110, 10, 500, 600, 100, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, string.Empty, "Site 4", 110, 120, 11, 550, 660, 100, 990, 1100)
            };
        }
    }
}
