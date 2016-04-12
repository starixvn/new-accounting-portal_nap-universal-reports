using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.Services
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class BasicWinLossServiceUnitTest
    {
        [Test]
        public void Query_ReturnRightBetTypeWinLossSummary()
        {
            // Arrange   
            var expectedBetTypeWinLossSummary = CreateExpectedBetTypeWinLossSummary();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeRawData();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new BasicWinLossServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreEqual(expectedBetTypeWinLossSummary, result);
            Assert.True(equal);
        }

        private BasicWinLossModel CreateExpectedBetTypeWinLossSummary()
        {
            var expectedSummaries = CreateExpectedSummaries();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new BasicWinLossModel
            {
                SiteWinLossSummaries = expectedSummaries,
                GrandTotal = expectedGrandTotal
            };
        }

        private List<RawWinLoss> CreateFakeRawData()
        {
            var site1Live = CreateFakeRawGroup(1, "Name 1");
            var site2Live = CreateFakeRawGroup(2, "Name 2");
            var allRMData = CreateFakeRMWinLoss();

            return (new List<List<RawWinLoss>> { site1Live, site2Live, allRMData })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawGroup(int groupId, string groupName)
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Credit", 100, 110, 10, 500, 600, -100, 100, 100, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(groupId, groupName, "Deposit", 110, 120, 11, 550, 660, -110, 100, 100, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        private List<RawWinLoss> CreateFakeRMWinLoss()
        {
            return new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(0, "RM", "8RM", 100, 110, 10, 500, 600, -100, 100, 100, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, "RM", "BARM", 110, 120, 11, 550, 660, -110, 100, 100, 990, 1100)
            };
        }

        private List<SiteWinLossSummary> CreateExpectedSummaries()
        {
            var site1 = CreateExpectedSiteSummaries(1, "Name 1");
            var site2 = CreateExpectedSiteSummaries(2, "Name 2");

            return new List<SiteWinLossSummary> { site1, site2 };
        }

        private SiteWinLossSummary CreateExpectedSiteSummaries(int id, string name)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(id, "Credit", 100, 110, 10, 500, 600, -100, 100, 100, 900, 1000, 500m / 900, 600m / 1000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(id, "Deposit", 110, 120, 11, 550, 660, -110, 100, 100, 990, 1100, 550m / 990, 660m / 1100);
            var totalWinLoss = WinLossFactory.CreateWinLoss(id, name, 210, 230, 21, 1050, 1260, -210, 100, 100, 1890, 2100, 1050m / 1890, 1260m / 2100);

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

        private bool AreEqual(BasicWinLossModel first, BasicWinLossModel second)
        {
            return Comparison.AreEqual(first.SiteWinLossSummaries, second.SiteWinLossSummaries)
                && Comparison.AreEqual(first.GrandTotal, second.GrandTotal);
        }
    }
}
