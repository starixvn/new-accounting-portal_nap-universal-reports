using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Products;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Products
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightProductWinLoss()
        {
            // Arrange   
            var expected = CreateExpectedProductWinLoss();
            var fakeData = CreateFakeData();
            var criteria = new FakeWinLossCriteria();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(criteria).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(criteria);

            // Assert
            ComparisonExtension.AreEqual(expected, result);
        }

        private List<RawWinLoss> CreateFakeData()
        {
            var sportsbookRaw = CreateFakeProductRawData(1, "Soccer");
            var sportsbookRMRaw = WinLossFactory.CreateRawWinLoss(0, "RM", "Soccer 8RM", 100, 110, 10, 500, 600, -100, 50, 450, 900, 1000);
            var nonSportsbookRaw = CreateFakeProductRawData(2, "Casino");

            var rawData = new List<RawWinLoss>();
            rawData.AddRange(sportsbookRaw);
            rawData.Add(sportsbookRMRaw);
            rawData.AddRange(nonSportsbookRaw);

            return rawData;
        }

        private ProductWinLoss CreateExpectedProductWinLoss()
        {
            var sportsbook = CreateExpectedProductGroupWinLoss(1, "Soccer", "Sportsbook Total");
            var nonSportsbook = CreateExpectedProductGroupWinLoss(2, "Casino", "Non-Sports Total");
            var sportsbookRM = CreateExpectedRMWinLoss();

            var grandTotal = CreateProductWinLossGrandTotal();

            return new ProductWinLoss
            {
                Sportsbook = sportsbook,
                NonSportsbook = nonSportsbook,
                RM = sportsbookRM,
                GrandTotal = grandTotal
            };
        }

        private List<WinLoss> CreateExpectedRMWinLoss()
        {
            return new List<WinLoss>
            {
               WinLossFactory.CreateWinLoss(0, "Soccer 8RM", 100, 110, 10, 500, 600, -100, 50, 450, 900, 1000, 500m / 900, 600m / 1000)
            };
        }

        private SiteWinLossSummary CreateProductWinLossGrandTotal()
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(1, "Credit", 200, 220, 20, 1000, 1200, -200, 100, 900, 1800, 2000, 1000m / 1800, 1200m / 2000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(1, "Deposit", 220, 240, 22, 1100, 1320, -220, 120, 980, 1980, 2200, 1100m / 1980, 1320m / 2200);
            var totalWinLoss = WinLossFactory.CreateWinLoss(1, "Grand Total", 420, 460, 42, 2100, 2520, -420, 220, 1880, 3780, 4200, 2100m / 3780, 2520m / 4200);

            return new SiteWinLossSummary
            {
                Credit = creditWinLoss,
                Deposit = depositWinLoss,
                Total = totalWinLoss
            };
        }

        [Test]
        public void GetProductGroup_ReturnRightGetProductGroupWinLoss()
        {
            // Arrange
            var expected = CreateExpectedProductGroupWinLoss(1, "Casino", "Non-Sports Total");
            var fakeData = CreateFakeProductRawData(1, "Casino");
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();

            // Act
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.GetProductGroup(fakeData, "Non-Sports Total");

            // Assert
            ComparisonExtension.AreEqual(expected, result);
        }

        private List<RawWinLoss> CreateFakeProductRawData(int productId, string productName)
        {
            var casinoCredit = WinLossFactory.CreateRawWinLoss(productId, productName, "Credit", 100, 110, 10, 500, 600, -100, 50, 450, 900, 1000);
            var casinoDeposit = WinLossFactory.CreateRawWinLoss(productId, productName, "Deposit", 110, 120, 11, 550, 660, -110, 60, 490, 990, 1100);

            return new List<RawWinLoss> { casinoCredit, casinoDeposit };
        }

        private ProductGroupWinLoss CreateExpectedProductGroupWinLoss(int productId, string productName, string groupTotalName)
        {
            var product = CreateExpectedProduct(productId, productName);
            var products = new List<SiteWinLossSummary> { product };

            return new ProductGroupWinLoss
            {
                Products = products,
                Total = CreateExpectedProduct(productId, groupTotalName)
            };
        }

        private SiteWinLossSummary CreateExpectedProduct(int productId, string productName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(productId, "Credit", 100, 110, 10, 500, 600, -100, 50, 450, 900, 1000, 500m / 900, 600m / 1000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(productId, "Deposit", 110, 120, 11, 550, 660, -110, 60, 490, 990, 1100, 550m / 990, 660m / 1100);
            var totalWinLoss = WinLossFactory.CreateWinLoss(productId, productName, 210, 230, 21, 1050, 1260, -210, 110, 940, 1890, 2100, 1050m / 1890, 1260m / 2100);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
