using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.LiveCasino.ThirdPartyProduct
{
    [TestFixture]
    [Category("Live Casino")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_Should_Return_Right_ThirdPartyProductWinLoss()
        {
            // Arrange
            var expectedProductSummaryWinLoss = CreateExpectedThirdPartyProductWinLoss();
            var rawService = Substitute.For<RawWinLossService>();
            var calculationService = new CalculationServiceImp();
            var fakeData = CreateFakeRawWinLoss();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            //Act
            var service = new ServiceImp(rawService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            //Assert
            var equal1 = WinLossComparision.AreTwoSiteWinLossSummaryListEqual(result.Products, expectedProductSummaryWinLoss.Products);
            var equal2 = WinLossComparision.AreTwoSiteWinLossSummaryEqual(result.GrandTotal, expectedProductSummaryWinLoss.GrandTotal);

            Assert.True(equal1);
            Assert.True(equal2);
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var sliCreditWinLoss = WinLossFactory.CreateRawWinLoss(4, "SLI", "Credit", 100, 110, 10, 300, 600, 600, 1000);
            var sliDepositWinLoss = WinLossFactory.CreateRawWinLoss(4, "SLI", "Deposit", 110, 120, 11, 100, 300, 400, 500);

            var agCasinoCreditWinLoss = WinLossFactory.CreateRawWinLoss(11, "AG Casino", "Credit", 100, 110, 10, 300, 600, 600, 1000);
            var agCasinoDepositWinLoss = WinLossFactory.CreateRawWinLoss(11, "AG Casino", "Deposit", 110, 120, 11, 100, 300, 400, 500);

            var goldDeluxeCreditWinLoss = WinLossFactory.CreateRawWinLoss(12, "Gold Deluxe", "Credit", 100, 110, 10, 300, 600, 600, 1000);
            var goldDeluxeDepositWinLoss = WinLossFactory.CreateRawWinLoss(12, "Gold Deluxe", "Deposit", 110, 120, 11, 100, 300, 400, 500);

            return new List<RawWinLoss> { sliCreditWinLoss, sliDepositWinLoss, agCasinoCreditWinLoss, agCasinoDepositWinLoss, goldDeluxeCreditWinLoss, goldDeluxeDepositWinLoss };
        }

        private WinLossModel CreateExpectedThirdPartyProductWinLoss()
        {
            return new WinLossModel
            {
                Products = CreateExpectedThirdPartyProduct(),
                GrandTotal = CreateExpectedGrandTotal()
            };
        }

        private List<SiteWinLossSummary> CreateExpectedThirdPartyProduct()
        {
            var sli = CreateExpectedThirdPartyProduct(4, "SLI");
            var agCasino = CreateExpectedThirdPartyProduct(11, "AG Casino");
            var goldDeluxe = CreateExpectedThirdPartyProduct(12, "Gold Deluxe");

            return new List<SiteWinLossSummary> { sli, agCasino, goldDeluxe };
        }

        private SiteWinLossSummary CreateExpectedThirdPartyProduct(int productId, string productName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(productId, "Credit", 100, 110, 10, 300, 600, -300, 600, 1000, 0.5m, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(productId, "Deposit", 110, 120, 11, 100, 300, -200, 400, 500, 0.25m, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(productId, productName, 210, 230, 21, 400, 900, -500, 1000, 1500, 0.4m, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(4, "Credit", 300, 330, 30, 900, 1800, -900, 1800, 3000, 0.5m, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(4, "Deposit", 330, 360, 33, 300, 900, -600, 1200, 1500, 0.25m, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(4, "Grand Total", 630, 690, 63, 1200, 2700, -1500, 3000, 4500, 0.4m, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
