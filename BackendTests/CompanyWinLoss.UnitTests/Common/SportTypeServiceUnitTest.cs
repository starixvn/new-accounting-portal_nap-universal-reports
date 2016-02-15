using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common
{
    public class SportTypeServiceUnitTest
    {
        [Test]
        [Category("CompanyWinLossUnitTests")]
        public void Query_ReturnRightSportTypeWinLossSummary()
        {
            // Arrange   
            var expectedSportTypeWinLossSummary = CreateExpectedSportTypeWinLossSummary();
            var calculationService = new CalculationServiceImp();
            var rawService = Substitute.For<RawService>();
            var fakeData = CreateFakeRawWinLoss();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new SportTypeServiceImp(rawService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreTwoSportTypeWinLossSummaryEqual(expectedSportTypeWinLossSummary, result);
            Assert.True(equal);
        }

        private SportTypeWinLossModel CreateExpectedSportTypeWinLossSummary()
        {
            var expectedSports = CreateExpectedListOfSportTypeWinLoss();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new SportTypeWinLossModel
            {
                Sports = expectedSports,
                GrandTotal = expectedGrandTotal
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var site1Live = CreateFakeRawSportTypeWinLoss(1, "SportType 1");
            var site2Live = CreateFakeRawSportTypeWinLoss(2, "SportType 2");
            return (new List<List<RawWinLoss>> { site1Live, site2Live })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawSportTypeWinLoss(int groupId, string groupName)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Credit", 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Deposit", 110, 120, 11, 550, 660, 990, 1100);

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
            var creditWinLoss = WinLossFactory.CreateWinLoss(sportTypeId, "Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(sportTypeId, "Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 550m / 990, 660m / 1100);
            var totalWinLoss = WinLossFactory.CreateWinLoss(sportTypeId, sportType, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 1050m / 1890, 1260m / 2100);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            return new SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 200, 220, 20, 1000, 1200, -200, 1800, 2000, 1000m / 1800, 1200m / 2000),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 220, 240, 22, 1100, 1320, -220, 1980, 2200, 1100m / 1980, 1320m / 2200),
                Total = WinLossFactory.CreateWinLoss(1, "Grand Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 2100m / 3780, 2520m / 4200)
            };
        }

        private bool AreTwoSportTypeWinLossSummaryEqual(SportTypeWinLossModel first, SportTypeWinLossModel second)
        {
            return WinLossComparision.AreTwoSiteWinLossSummaryListEqual(first.Sports, second.Sports)
                && WinLossComparision.AreTwoSiteWinLossSummaryEqual(first.GrandTotal, second.GrandTotal);
        }
    }
}
