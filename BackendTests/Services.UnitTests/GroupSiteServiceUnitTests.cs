using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.Main
{
    public class GroupSiteServiceUnitTests
    {
        [Test]
        [Category("ServiceUnitTests")]
        public void Query_CalculateGroupSiteWinLoss()
        {
            // Arrange   
            var calculationService = new CalculationService();
            var rawWinLossService = Substitute.For<IRawWinLossService>();

            // Act 
            var service = Substitute.ForPartsOf<GroupOfSiteService>(rawWinLossService, calculationService);
            service.CalculateGroupSiteWinLoss(Arg.Any<IEnumerable<RawWinLoss>>()).Returns(new GroupOfSiteWinLoss());

            var criteria = new WinLossCriteria();
            var result = service.Query(criteria);

            // Assert
            service.Received().CalculateGroupSiteWinLoss(Arg.Any<IEnumerable<RawWinLoss>>());
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var site1Live = CreateFakeRawGroupWinLoss("Site 1", true);
            var site2Live = CreateFakeRawGroupWinLoss("Site 2", true);
            var site1NoneLive = CreateFakeRawGroupWinLoss("Site 1", false);
            var site2NoneLive = CreateFakeRawGroupWinLoss("Site 2", false);
            return (new List<List<RawWinLoss>> { site1Live, site2Live, site1NoneLive, site2NoneLive })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawGroupWinLoss(string groupName, bool isLive)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(groupName, "Credit", isLive, 100, 200, 10, 300, 400, 1000, 1200);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(groupName, "Deposit", isLive, 110, 210, 20, 310, 410, 1100, 1300);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        [Test]
        [Category("ServiceUnitTests")]
        public void CalculateGroupSiteWinLoss_ReturnRightGroupSiteWinLoss()
        {
            // Arrange   
            var expectedGroupSiteWinLoss = CreateExpectedGroupSiteWinLoss();
            var calculationService = new CalculationService();
            var rawWinLossService = Substitute.For<IRawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new GroupOfSiteService(rawWinLossService, calculationService);
            var result = service.CalculateGroupSiteWinLoss(fakeData);

            // Assert
            var equal = WinLossComparision.AreTwoGroupSiteWinLossEqual(expectedGroupSiteWinLoss, result);
            Assert.True(equal);
        }

        private GroupOfSiteWinLoss CreateExpectedGroupSiteWinLoss()
        {
            var expectedProducts = CreateExpectedListOfSiteWinLoss();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new GroupOfSiteWinLoss
            {
                Live = expectedProducts,
                NonLive = expectedProducts,
                LiveGrandTotal = expectedGrandTotal,
                NonLiveGrandTotal = expectedGrandTotal,
            };
        }

        private List<SiteWinLoss> CreateExpectedListOfSiteWinLoss()
        {
            var site1 = CreateExpectedSiteWinLoss("Site 1");
            var site2 = CreateExpectedSiteWinLoss("Site 2");

            return new List<SiteWinLoss> { site1, site2 };
        }

        private SiteWinLoss CreateExpectedSiteWinLoss(string siteName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss("Credit", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var depositWinLoss = WinLossFactory.CreateWinLoss("Deposit", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100, 410m / 1300);
            var totalWinLoss = WinLossFactory.CreateWinLoss(siteName, 210, 410, 30, 610, 810, -200, 2100, 2500, 610m / 2100, 810m / 2500);

            return new SiteWinLoss { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private SiteWinLoss CreateExpectedGrandTotal()
        {
            return new SiteWinLoss
            {
                Credit = WinLossFactory.CreateWinLoss("Credit", 200, 400, 20, 600, 800, -200, 2000, 2400, 600m / 2000, 800m / 2400),
                Deposit = WinLossFactory.CreateWinLoss("Deposit", 220, 420, 40, 620, 820, -200, 2200, 2600, 620m / 2200, 820m / 2600),
                Total = WinLossFactory.CreateWinLoss("Grand Total", 420, 820, 60, 1220, 1620, -400, 4200, 5000, 1220m / 4200, 1620m / 5000),
            };
        }
    }
}
