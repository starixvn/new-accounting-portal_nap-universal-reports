using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Models.Main;
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
        [Category("ServiceUnitTests")]
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
            var liveWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Live", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var nonLiveWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Non-Live", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);
            var parlayWinLoss = WinLossFactory.CreateWinLoss("Parlay", 120, 130, 12, 600, 720, -120, 1080, 1200, 5m / 9, 0.6m);
            var outrightWinLoss = WinLossFactory.CreateWinLoss("Outright", 130, 140, 13, 650, 780, -130, 1170, 1300, 5m / 9, 0.6m);

            return new List<WinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }


        [Test]
        [Category("ServiceUnitTests")]
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
            var equal = WinLossComparision.AreTwoMainWinLossEqual(expectedMainWinLoss, result);
            Assert.True(equal);
        }

        private MainWinLoss CreateExpectedMainWinLoss()
        {
            var expectedSportsbookDetail = CreateExpectedSportsbookDetail();
            var expectedProducts = CreateExpectedProducts();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new MainWinLoss
            {
                GrandTotal = expectedGrandTotal,
                Products = expectedProducts,
                SportsbookDetail = expectedSportsbookDetail
            };
        }

        private List<SiteWinLoss> CreateExpectedProducts()
        {
            var sportsbook = CreateExpectedProduct("Sportsbook");
            var numberGame = CreateExpectedProduct("Number Game");

            return new List<SiteWinLoss> { sportsbook, numberGame };
        }

        private SiteWinLoss CreateExpectedProduct(string productName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss("Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss("Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(productName, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 5m / 9, 0.6m);

            return new SiteWinLoss { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var sportsbookDetail = CreateFakeSportsbookDetail();
            var sportsbook = CreateFakeRawProductWinLoss("Sportsbook");
            var numberGame = CreateFakeRawProductWinLoss("Number Game");

            return (new List<List<RawWinLoss>> { sportsbookDetail, sportsbook, numberGame })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeSportsbookDetail()
        {
            var liveWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Detail", "Sportsbook Live", 100, 110, 10, 500, 600, 900, 1000);
            var nonLiveWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Detail", "Sportsbook Non-Live", 110, 120, 11, 550, 660, 990, 1100);
            var parlayWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Detail", "Parlay", 120, 130, 12, 600, 720, 1080, 1200);
            var outrightWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Detail", "Outright", 130, 140, 13, 650, 780, 1170, 1300);

            return new List<RawWinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }

        private List<RawWinLoss> CreateFakeRawProductWinLoss(string productName)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(productName, "Credit", 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(productName, "Deposit", 110, 120, 11, 550, 660, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        private SiteWinLoss CreateExpectedGrandTotal()
        {
            return new SiteWinLoss
            {
                Credit = WinLossFactory.CreateWinLoss("Credit", 200, 220, 20, 1000, 1200, -200, 1800, 2000, 5m / 9, 0.6m),
                Deposit = WinLossFactory.CreateWinLoss("Deposit", 220, 240, 22, 1100, 1320, -220, 1980, 2200, 5m / 9, 0.6m),
                Total = WinLossFactory.CreateWinLoss("Grand Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 5m / 9, 0.6m),
            };
        }
    }
}
