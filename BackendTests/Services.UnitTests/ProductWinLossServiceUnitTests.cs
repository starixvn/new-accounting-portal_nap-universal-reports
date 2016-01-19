using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    public class ProductWinLossServiceUnitTests
    {
        [Test]
        public void CalculateSportsbookDetail_ReturnRightSportsbookDetail()
        {
            // Arrange   
            var expectedProducts = CreateExpectedSportsbookDetail();
            var calculationService = new CalculationService();
            var rawWinLossService = Substitute.For<IRawWinLossService>();
            var fakeData = CreateFakeSportsbookDetail();

            // Act 
            var service = new ProductWinLossService(rawWinLossService, calculationService);
            var result = service.CalculateSportsbookDetail(fakeData);

            // Assert
            var equal1 = WinLossComparision.AreTwoWinLossEqual(expectedProducts[0], result[0]);
            var equal2 = WinLossComparision.AreTwoWinLossEqual(expectedProducts[1], result[1]);
            var equal3 = WinLossComparision.AreTwoWinLossEqual(expectedProducts[2], result[2]);
            var equal4 = WinLossComparision.AreTwoWinLossEqual(expectedProducts[3], result[3]);

            Assert.True(equal1);
            Assert.True(equal2);
            Assert.True(equal3);
            Assert.True(equal4);
        }

        private List<WinLoss> CreateExpectedSportsbookDetail()
        {
            var liveWinLoss = WinLossFactory.CreateWinLoss(0, "Sportsbook Live", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var nonLiveWinLoss = WinLossFactory.CreateWinLoss(0, "Sportsbook Non-Live", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);
            var parlayWinLoss = WinLossFactory.CreateWinLoss(0, "Parlay", 120, 130, 12, 600, 720, -120, 1080, 1200, 5m / 9, 0.6m);
            var outrightWinLoss = WinLossFactory.CreateWinLoss(0, "Outright", 130, 140, 13, 650, 780, -130, 1170, 1300, 5m / 9, 0.6m);

            return new List<WinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }

        [Test]
        public void CalculateMainWinLoss_ReturnRightMainWinLoss()
        {
            // Arrange   
            var expectedMainWinLoss = CreateExpectedMainWinLoss();
            var calculationService = new CalculationService();
            var rawWinLossService = Substitute.For<IRawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new ProductWinLossService(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = WinLossComparision.AreTwoProductWinLossEqual(expectedMainWinLoss, result);
            Assert.True(equal);
        }

        private ProductWinLoss CreateExpectedMainWinLoss()
        {
            var expectedSportsbookDetail = CreateExpectedSportsbookDetail();
            var expectedProducts = CreateExpectedProducts();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new ProductWinLoss
            {
                GrandTotal = expectedGrandTotal,
                Products = expectedProducts,
                SportsbookDetail = expectedSportsbookDetail
            };
        }

        private List<SiteWinLossSummary> CreateExpectedProducts()
        {
            var sportsbook = CreateExpectedProduct(1, "Sportsbook");
            var numberGame = CreateExpectedProduct(2, "Number Game");

            return new List<SiteWinLossSummary> { sportsbook, numberGame };
        }

        private SiteWinLossSummary CreateExpectedProduct(int productId, string productName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(productId, "Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(productId, "Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(productId, productName, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 5m / 9, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var sportsbookDetail = CreateFakeSportsbookDetail();
            var sportsbook = CreateFakeRawProductWinLoss(1, "Sportsbook");
            var numberGame = CreateFakeRawProductWinLoss(2, "Number Game");

            return (new List<List<RawWinLoss>> { sportsbookDetail, sportsbook, numberGame })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeSportsbookDetail()
        {
            var liveWinLoss = WinLossFactory.CreateRawWinLoss(0, "Sportsbook Detail", "Sportsbook Live", 100, 110, 10, 500, 600, 900, 1000);
            var nonLiveWinLoss = WinLossFactory.CreateRawWinLoss(0, "Sportsbook Detail", "Sportsbook Non-Live", 110, 120, 11, 550, 660, 990, 1100);
            var parlayWinLoss = WinLossFactory.CreateRawWinLoss(0, "Sportsbook Detail", "Parlay", 120, 130, 12, 600, 720, 1080, 1200);
            var outrightWinLoss = WinLossFactory.CreateRawWinLoss(0, "Sportsbook Detail", "Outright", 130, 140, 13, 650, 780, 1170, 1300);

            return new List<RawWinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }

        private List<RawWinLoss> CreateFakeRawProductWinLoss(int productId, string productName)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(productId, productName, "Credit", 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(productId, productName, "Deposit", 110, 120, 11, 550, 660, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            return new SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(0, "Credit", 200, 220, 20, 1000, 1200, -200, 1800, 2000, 5m / 9, 0.6m),
                Deposit = WinLossFactory.CreateWinLoss(0, "Deposit", 220, 240, 22, 1100, 1320, -220, 1980, 2200, 5m / 9, 0.6m),
                Total = WinLossFactory.CreateWinLoss(0, "GRAND TOTAL", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 5m / 9, 0.6m),
            };
        }
    }
}
