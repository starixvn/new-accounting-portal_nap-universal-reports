using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.Main
{
    public class MainReportServiceUnitTests
    {
        [Test]
        [Category("ServiceUnitTests")]
        public void CalculateGrandTotal_SportsbookAndNumberGame_ReturnRightGrandTotal()
        {
            // Arrange   
            var expectedGrandTotal = CreateExpectedGrandTotal();
            var calculationService = new CalculationService();
            var rawWinLossService = Substitute.For<IRawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new MainService(rawWinLossService, calculationService);
            var result = service.CalculateGrandTotal(fakeData);

            // Assert
            var equal = WinLossComparision.AreTwoProductWinLossEqual(expectedGrandTotal, result);
            Assert.True(equal);
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
            var liveWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Detail", "Sportsbook Live", 100, 200, 10, 300, 400, 1000, 1200);
            var nonLiveWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Detail", "Sportsbook Non-Live", 110, 210, 20, 310, 410, 1100, 1300);
            var parlayWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Detail", "Parlay", 120, 220, 30, 320, 420, 1200, 1400);
            var outrightWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Detail", "Outright", 130, 230, 40, 330, 430, 1300, 1500);

            return new List<RawWinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }

        private List<RawWinLoss> CreateFakeRawProductWinLoss(string productName)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(productName, "Credit", 100, 200, 10, 300, 400, 1000, 1200);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(productName, "Deposit", 110, 210, 20, 310, 410, 1100, 1300);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        private ProductWinLoss CreateExpectedGrandTotal()
        {
            return new ProductWinLoss
            {
                Credit = WinLossFactory.CreateWinLoss("Credit", 200, 400, 20, 600, 800, -200, 2000, 2400, 600m / 2000, 800m / 2400),
                Deposit = WinLossFactory.CreateWinLoss("Deposit", 220, 420, 40, 620, 820, -200, 2200, 2600, 620m / 2200, 820m / 2600),
                Total = WinLossFactory.CreateWinLoss("Grand Total", 420, 820, 60, 1220, 1620, -400, 4200, 5000, 1220m / 4200, 1620m / 5000),
            };
        }

        [Test]
        [Category("ServiceUnitTests")]
        public void CalculateProductWinLoss_SportsbookAndNumberGame_ReturnRightProducts()
        {
            // Arrange   
            var expectedProducts = CreateExpectedProducts();
            var calculationService = new CalculationService();
            var rawWinLossService = Substitute.For<IRawWinLossService>();
            var fakeData = CreateFakeProductRawWinLoss();

            // Act 
            var service = new MainService(rawWinLossService, calculationService);
            var result = service.CalculateProductWinLoss(fakeData).ToList();

            // Assert
            var equal1 = WinLossComparision.AreTwoProductWinLossEqual(expectedProducts[0], result[0]);
            var equal2 = WinLossComparision.AreTwoProductWinLossEqual(expectedProducts[1], result[1]);
            Assert.True(equal1);
            Assert.True(equal2);
        }

        private List<RawWinLoss> CreateFakeProductRawWinLoss()
        {
            var sportsbook = CreateFakeRawProductWinLoss("Sportsbook");
            var numberGame = CreateFakeRawProductWinLoss("Number Game");

            return (new List<List<RawWinLoss>> { sportsbook, numberGame })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<ProductWinLoss> CreateExpectedProducts()
        {
            var sportsbook = CreateExpectedProduct("Sportsbook");
            var numberGame = CreateExpectedProduct("Number Game");

            return new List<ProductWinLoss> { sportsbook, numberGame };
        }

        private ProductWinLoss CreateExpectedProduct(string productName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss("Credit", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var depositWinLoss = WinLossFactory.CreateWinLoss("Deposit", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100, 410m / 1300);
            var totalWinLoss = WinLossFactory.CreateWinLoss(productName, 210, 410, 30, 610, 810, -200, 2100, 2500, 610m / 2100, 810m / 2500);

            return new ProductWinLoss { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

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
            var service = new MainService(rawWinLossService, calculationService);
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
            var liveWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var nonLiveWinLoss = WinLossFactory.CreateWinLoss("Sportsbook Non-Live", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100, 410m / 1300);
            var parlayWinLoss = WinLossFactory.CreateWinLoss("Parlay", 120, 220, 30, 320, 420, -100, 1200, 1400, 320m / 1200, 420m / 1400);
            var outrightWinLoss = WinLossFactory.CreateWinLoss("Outright", 130, 230, 40, 330, 430, -100, 1300, 1500, 330m / 1300, 430m / 1500);

            return new List<WinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }

        [Test]
        [Category("ServiceUnitTests")]
        public void Query_CalculateMainWinLoss()
        {
            // Arrange   
            var calculationService = new CalculationService();
            var rawWinLossService = Substitute.For<IRawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<MainQuery>()).Returns(fakeData);

            // Act 
            var service = Substitute.ForPartsOf<MainService>(rawWinLossService, calculationService);
            service.CalculateMainWinLoss(Arg.Any<IEnumerable<RawWinLoss>>()).Returns(new MainWinLoss());

            var query = new MainQuery();
            var result = service.Query(query);

            // Assert
            service.Received().CalculateMainWinLoss(Arg.Any<IEnumerable<RawWinLoss>>());
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

            // Act 
            var service = new MainService(rawWinLossService, calculationService);
            var result = service.CalculateMainWinLoss(fakeData);

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
    }
}
