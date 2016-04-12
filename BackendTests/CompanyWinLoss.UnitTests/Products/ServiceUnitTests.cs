using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
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
        public void CalculateSportsbookDetail_ReturnRightSportsbookDetail()
        {
            // Arrange   
            var expectedProducts = CreateExpectedSportsbookDetail();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeSportsbookDetail();

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.CalculateSportsbookDetail(fakeData);

            // Assert
            var equal1 = Comparison.AreEqual(expectedProducts[0], result[0]);
            var equal2 = Comparison.AreEqual(expectedProducts[1], result[1]);
            var equal3 = Comparison.AreEqual(expectedProducts[2], result[2]);
            var equal4 = Comparison.AreEqual(expectedProducts[3], result[3]);

            Assert.True(equal1);
            Assert.True(equal2);
            Assert.True(equal3);
            Assert.True(equal4);
        }
        private List<RawWinLoss> CreateFakeSportsbookDetail()
        {
            var liveWinLoss = WinLossFactory.CreateRawWinLoss(0, "Sportsbook Detail", "Sportsbook Live", 100, 110, 10, 500, 600, -100, 100, 100, 900, 1000);
            var nonLiveWinLoss = WinLossFactory.CreateRawWinLoss(0, "Sportsbook Detail", "Sportsbook Non-Live", 110, 120, 11, 550, 660, -110, 100, 100, 990, 1100);
            var parlayWinLoss = WinLossFactory.CreateRawWinLoss(0, "Sportsbook Detail", "Parlay", 120, 130, 12, 600, 720, -120, 100, 100, 1080, 1200);
            var outrightWinLoss = WinLossFactory.CreateRawWinLoss(0, "Sportsbook Detail", "Outright", 130, 140, 13, 650, 780, -130, 100, 100, 1170, 1300);

            return new List<RawWinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }
        private List<WinLoss> CreateExpectedSportsbookDetail()
        {
            var liveWinLoss = WinLossFactory.CreateWinLoss(0, "Sportsbook Live", 100, 110, 10, 500, 600, -100, 100, 100, 900, 1000, 500m / 900, 600m / 1000);
            var nonLiveWinLoss = WinLossFactory.CreateWinLoss(0, "Sportsbook Non-Live", 110, 120, 11, 550, 660, -110, 100, 100, 990, 1100, 550m / 990, 660m / 1100);
            var parlayWinLoss = WinLossFactory.CreateWinLoss(0, "Parlay", 120, 130, 12, 600, 720, -120, 100, 100, 1080, 1200, 600m / 1080, 720m / 1200);
            var outrightWinLoss = WinLossFactory.CreateWinLoss(0, "Outright", 130, 140, 13, 650, 780, -130, 100, 100, 1170, 1300, 650m / 1170, 780m / 1300);

            return new List<WinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }
        [Test]
        public void GetNoneSportbookProducts_ReturnRightNoneSportbookProducts()
        {
            //Arrange
            var expectedProducts = CreateExpectedNoneSportsbook();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeNoneSportsbook();

            //Act
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.GetNoneSportbookProducts(fakeData);
            //Assert
            var equal1 = Comparison.AreEqual(expectedProducts.Products[0].Total, result.Products[0].Total);
            Assert.True(equal1);
        }
        private List<RawWinLoss> CreateFakeNoneSportsbook()
        {
            var casino = WinLossFactory.CreateRawWinLoss(1, "Casino", "Casino", 210, 230, 21, 1050, 1260, -210, 200, 200, 1890, 2100);

            return new List<RawWinLoss> { casino};
        }
        private NoneSportsbookWinloss CreateExpectedNoneSportsbook()
        {
            return new NoneSportsbookWinloss
            {
                Products = CreateExpectedProducts(),
                Total = CreateExpectedProduct(1, "Non-Sports Total")
            };
        }

        private List<SiteWinLossSummary> CreateExpectedProducts()
        {
            var casino = CreateExpectedProduct(1, "Casino");
            return new List<SiteWinLossSummary> { casino};
        }

        private SiteWinLossSummary CreateExpectedProduct(int productId, string productName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(productId, "Credit", 100, 110, 10, 500, 600, -100, 100, 100, 900, 1000, 500m / 900, 600m / 1000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(productId, "Deposit", 110, 120, 11, 550, 660, -110, 100, 100, 990, 1100, 550m / 990, 660m / 1100);
            var totalWinLoss = WinLossFactory.CreateWinLoss(productId, productName, 210, 230, 21, 1050, 1260, -210, 200, 200, 1890, 2100, 1050m / 1890, 1260m / 2100);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
