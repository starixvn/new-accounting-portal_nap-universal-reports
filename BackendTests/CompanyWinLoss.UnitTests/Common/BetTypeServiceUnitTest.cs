using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class BetTypeServiceUnitTest
    {
        [Test]
        public void Query_ReturnRightBetTypeWinLossSummary()
        {
            // Arrange   
            var expectedBetTypeWinLossSummary = CreateExpectedBetTypeWinLossSummary();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new BetTypeServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreTwoBetTypeWinLossSummaryEqual(expectedBetTypeWinLossSummary, result);
            Assert.True(equal);
        }

        private BetTypeWinLossModel CreateExpectedBetTypeWinLossSummary()
        {
            var expectedBetTypeWinLosses = CreateExpectedListOfBetTypeWinLoss();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new BetTypeWinLossModel
            {
                BetTypes = expectedBetTypeWinLosses,
                GrandTotal = expectedGrandTotal
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var site1Live = CreateFakeRawBetTypeWinLoss(1, "BetType 1");
            var site2Live = CreateFakeRawBetTypeWinLoss(2, "BetType 2");
            return (new List<List<RawWinLoss>> { site1Live, site2Live })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawBetTypeWinLoss(int groupId, string groupName)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Credit", 100, 110, 10, 500, 600, 100, 100, 100, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Deposit", 110, 120, 11, 550, 660, 100, 100, 100, 990, 1100);

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
            var creditWinLoss = WinLossFactory.CreateWinLoss(betTypeId, "Credit", 100, 110, 10, 500, 600, -100, 100, 100, 900, 1000, 500m / 900, 600m / 1000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(betTypeId, "Deposit", 110, 120, 11, 550, 660, -110, 100, 100, 990, 1100, 550m / 990, 660m / 1100);
            var totalWinLoss = WinLossFactory.CreateWinLoss(betTypeId, betType, 210, 230, 21, 1050, 1260, -210, 100, 100, 1890, 2100, 1050m / 1890, 1260m / 2100);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            return new SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 200, 220, 20, 1000, 1200, -200, 100, 100, 1800, 2000, 1000m / 1800, 1200m / 2000),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 220, 240, 22, 1100, 1320, -220, 100, 100, 1980, 2200, 1100m / 1980, 1320m / 2200),
                Total = WinLossFactory.CreateWinLoss(1, "All Total", 420, 460, 42, 2100, 2520, -420, 100, 100, 3780, 4200, 2100m / 3780, 2520m / 4200)
            };
        }

        private bool AreTwoBetTypeWinLossSummaryEqual(BetTypeWinLossModel first, BetTypeWinLossModel second)
        {
            return WinLossComparision.AreTwoSiteWinLossSummaryListEqual(first.BetTypes, second.BetTypes)
                && WinLossComparision.AreTwoSiteWinLossSummaryEqual(first.GrandTotal, second.GrandTotal);
        }
    }
}
