using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;
using UniversalReports.CompanyWinLoss.VirtualSports.Summary;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.Summary
{
    public class ServiceTests
    {
        [Test]
        public void Query_ReturnRightVirtualSportsSportTypeWinLossSummary()
        {
            // Arrange   
            var expectedVirtualSportsSportTypeWinLossSummary = CreateExpectedVirtualSportsSportTypeWinLossSummary();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreTwoVirtualSportsSportTypeWinLossSummaryEqual(expectedVirtualSportsSportTypeWinLossSummary, result);
            Assert.True(equal);
        }

        private WinLossModel CreateExpectedVirtualSportsSportTypeWinLossSummary()
        {
            var expectedSports = CreateExpectedListOfSportTypeWinLoss();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new WinLossModel
            {
                Sports = expectedSports,
                GrandTotal = expectedGrandTotal
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var site1Live = CreateFakeRawSportTypeWinLoss(1, "SportType 1", true);
            var site2Live = CreateFakeRawSportTypeWinLoss(2, "SportType 2", true);
            return (new List<List<RawWinLoss>> { site1Live, site2Live })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawSportTypeWinLoss(int groupId, string groupName, bool isLive)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Credit", isLive, 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Deposit", isLive, 110, 120, 11, 550, 660, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        private List<SiteWinLossSummary> CreateExpectedListOfSportTypeWinLoss()
        {
            var site1 = CreateExpectedSportTypeWinLoss(1, "SportType 1");
            var site2 = CreateExpectedSportTypeWinLoss(2, "SportType 2");

            return new List<SiteWinLossSummary> { site1, site2 };
        }

        private SiteWinLossSummary CreateExpectedSportTypeWinLoss(int sportTypeId, string sportType)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(sportTypeId, "Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(sportTypeId, "Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(sportTypeId, sportType, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 5m / 9, 0.6m);

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

        private bool AreTwoVirtualSportsSportTypeWinLossSummaryEqual(WinLossModel first, WinLossModel second)
        {
            return WinLossComparision.AreTwoSiteWinLossSummaryListEqual(first.Sports, second.Sports)
                && WinLossComparision.AreTwoSiteWinLossSummaryEqual(first.GrandTotal, second.GrandTotal);
        }
    }
}
