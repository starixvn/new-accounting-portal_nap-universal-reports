using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Soccer.BetType;
using UniversalReports.CompanyWinLoss.Soccer.GroupBetType;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Soccer.GroupBetType
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void CalculateSiteWinLossSummary_ReturnRight()
        {
            //// Arrange

            var expectedSummary = CreateExpectedSummary();
            var fakeData = CreateFakeRawWinLossSummary();
            var calculatorService = new CompanyWinLoss.Soccer.BetType.CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            //// Act
            var service = new WinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            //// Assert
            ComparisonExtension.AreEqual(expectedSummary.SiteWinLossSummaries[0], result.SiteWinLossSummaries[0]);
        }

        public WinLossModel CreateExpectedSummary()
        {
            var siteWinLossSummaries = CreateSiteWinLossSummaries();
            return new WinLossModel
            {
                SiteWinLossSummaries = siteWinLossSummaries,
                GrandTotal = null,
                MainTotal = null,
                OtherTotal = null,
                RM = null
            };
        }

        public List<RawWinLoss> CreateFakeRawWinLossSummary()
        {
            List<RawWinLoss> result = new List<RawWinLoss>();
            result.Add(SoccerWinLossFactory.CreateRawWinLoss(1, "Grand Total", "Credit", true, 10, 10, 10, 10, 10, 10, 10, 10));
            result.Add(SoccerWinLossFactory.CreateRawWinLoss(1, "Grand Total", "Deposit", true, 10, 10, 10, 10, 10, 10, 10, 10));
            return result;
        }

        public List<WinLossSummaryByBetTypeGroup> CreateSiteWinLossSummaries()
        {
            List<WinLossSummaryByBetTypeGroup> result = new List<WinLossSummaryByBetTypeGroup>();
            result.Add(CreateSummaryByBetTypeGroup());
            return result;
        }

        public WinLossSummaryByBetTypeGroup CreateSummaryByBetTypeGroup()
        {
            List<SiteWinLossSummary> siteWinLossSummaries = new List<SiteWinLossSummary>();
            siteWinLossSummaries.Add(CreateExpectedGrandTotal());
            var total = WinLossFactory.CreateWinLoss(0, "TOTAL", 20, 20, 20, 20, 20, 20, 0, 0, 20, 20, 1, 1);
            return new WinLossSummaryByBetTypeGroup
            {
                SiteWinLossSummaries = siteWinLossSummaries,
                Total = total
            };
        }

        public SiteWinLossSummary CreateExpectedGrandTotal()
        {
            var credit = WinLossFactory.CreateWinLoss(1, "Credit", 10, 10, 10, 10, 10, 10, 0, 0, 10, 10, 1, 1);
            var deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 10, 10, 10, 10, 10, 10, 0, 0, 10, 10, 1, 1);
            var total = WinLossFactory.CreateWinLoss(1, "Grand Total", 20, 20, 20, 20, 20, 20, 0, 0, 20, 20, 1, 1);

            return new SiteWinLossSummary
            {
                Credit = credit,
                Deposit = deposit,
                Total = total
            };
        }

        public List<RawWinLoss> CreateFakeRawWinLoss()
        {
            List<RawWinLoss> result = new List<RawWinLoss>();
            result.Add(SoccerWinLossFactory.CreateRawWinLoss(1, "BetType 1", "Credit", true, 10, 10, 10, 10, 10, 10, 10, 10));
            result.Add(SoccerWinLossFactory.CreateRawWinLoss(1, "BetType 1", "Deposit", true, 10, 10, 10, 10, 10, 10, 10, 10));
            result.Add(SoccerWinLossFactory.CreateRawWinLoss(1, "RM", "Deposit", true, 0, 0, 0, 0, 0, 0, 0, 0));
            return result;
        }
    }
}
