using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.Main
{
    public class NumberGameBetTypeWinLossSummaryServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightNumberGameBetTypeWinLossSummary()
        {
            // Arrange   
            var expectedNumberGameBetTypeWinLossSummary = CreateExpectedNumberGameBetTypeWinLossSummary();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new NumberGameBetTypeSummaryWinLossServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = WinLossComparision.AreTwoGroupSiteWinLossEqual(expectedNumberGameBetTypeWinLossSummary, result);
            Assert.True(equal);
        }

        private NumberGameBetTypeWinLossSummary CreateExpectedNumberGameBetTypeWinLossSummary()
        {
            var expectedProducts = CreateExpectedListOfBetTypeWinLoss();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new NumberGameBetTypeWinLossSummary
            {
                Live = expectedProducts,
                NonLive = expectedProducts,
                LiveGrandTotal = expectedGrandTotal,
                NonLiveGrandTotal = expectedGrandTotal,
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var site1Live = CreateFakeRawBetTypeWinLoss(1, "BetType 1", true);
            var site2Live = CreateFakeRawBetTypeWinLoss(2, "BetType 2", true);
            var site1NoneLive = CreateFakeRawBetTypeWinLoss(1, "BetType 1", false);
            var site2NoneLive = CreateFakeRawBetTypeWinLoss(2, "BetType 2", false);
            return (new List<List<RawWinLoss>> { site1Live, site2Live, site1NoneLive, site2NoneLive })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawBetTypeWinLoss(int groupId, string groupName, bool isLive)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Credit", isLive, 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Deposit", isLive, 110, 120, 11, 550, 660, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        private List<SiteWinLossSummary> CreateExpectedListOfBetTypeWinLoss()
        {
            var site1 = CreateExpectedBetTypeWinLoss(1, "BetType 1");
            var site2 = CreateExpectedBetTypeWinLoss(2, "BetType 2");

            return new List<SiteWinLossSummary> { site1, site2 };
        }

        private SiteWinLossSummary CreateExpectedBetTypeWinLoss(int betTypeId, string betType)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(betTypeId, "Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(betTypeId, "Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(betTypeId, betType, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 5m / 9, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            return new SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 200, 220, 20, 1000, 1200, -200, 1800, 2000, 5m / 9, 0.6m),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 220, 240, 22, 1100, 1320, -220, 1980, 2200, 5m / 9, 0.6m),
                Total = WinLossFactory.CreateWinLoss(1, "All Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 5m / 9, 0.6m)
            };
        }
    }
}
