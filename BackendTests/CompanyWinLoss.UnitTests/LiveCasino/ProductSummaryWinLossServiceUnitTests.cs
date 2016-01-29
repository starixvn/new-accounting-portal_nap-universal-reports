using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.LiveCasino;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.LiveCasino
{
    [TestFixture]
    [Category("Live Casino")]
    public class ProductSummaryWinLossServiceUnitTests
    {
        [Test]
        public void Should_Return_Right_LiveCasinoProductSummaryWinLoss()
        {
            // Arrange
            var expectedLiveCasinoProductSummaryWinLoss = CreateExpectedProductSummaryWinLoss();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var calculationService = Substitute.For<CalculationService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);


            //Act
            var service = new ProductSummaryWinLossServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            //Assert
            var equal1 = WinLossComparision.AreTwoSiteWinLossSummaryListEqual(result.Products, expectedLiveCasinoProductSummaryWinLoss.Products);
            var equal2 = WinLossComparision.AreTwoSiteWinLossSummaryEqual(result.GrandTotal, expectedLiveCasinoProductSummaryWinLoss.GrandTotal);

            Assert.True(equal1);
            Assert.True(equal2);
        }

        private ProductSummaryWinLoss CreateExpectedProductSummaryWinLoss()
        {
            return new ProductSummaryWinLoss
            {
                Products = CreateExpectedProduct(),
                GrandTotal = CreateExpectedGrandTotal()
            };
        }

        private List<SiteWinLossSummary> CreateExpectedProduct()
        {
            var sli = CreateExpectedProduct(4, "SLI");
            var agCasino = CreateExpectedProduct(11, "AG Casino");
            var goldDeluxe = CreateExpectedProduct(12, "Gold Deluxe");

            return new List<SiteWinLossSummary> { sli, agCasino, goldDeluxe };
        }

        private SiteWinLossSummary CreateExpectedProduct(int productId, string productName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(productId, "Credit", 100, 110, 10, 300, 600, -300, 600, 1000, 0.5m, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(productId, "Deposit", 110, 120, 11, 100, 300, -200, 400, 500, 0.25m, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(productId, productName, 210, 230, 21, 400, 900, -500, 1000, 1500, 0.25m, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
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

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(0, "Credit", 300, 310, 30, 900, 1800, -900, 1800, 3000, 0.5m, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(0, "Deposit", 330, 360, 33, 300, 900, -600, 1200, 1500, 0.25m, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(0, "All Total", 630, 670, 63, 1200, 2700, -1500, 3000, 4500, 0.4m, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
