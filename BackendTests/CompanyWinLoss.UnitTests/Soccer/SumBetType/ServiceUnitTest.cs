using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Soccer.SumBetType;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Soccer.SumBetType
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTest
    {
        [Test]
        public void CalculateSum_ReturnRight()
        {
            //// Arrange
            var expectedCaculateSum = CreateExpectedCaculateSum();
            var fakeData = CreateFakeRawWinLoss();
            var calculatorService = new CompanyWinLoss.Soccer.BetType.CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            //// Act
            var service = new WinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            //// Assert
            var equal = AreTwoSoccerBetTypeWinLossSummaryEqual(expectedCaculateSum, result);
            Assert.True(equal);
        }

        [Test]
        public void CalculateSiteWinLossSummary_ReturnRight()
        {
            //// Arrange

            var expectedCalculateSiteWinLossSummary = CreateExpectedSummary();

            var fakeData = CreateFakeRawWinLossSummary();
            var calculatorService = new CompanyWinLoss.Soccer.BetType.CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            //// Act
            var service = new WinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            //// Assert
            var equal = AreTwoCalculateSiteWinLossSummaryEqual(expectedCalculateSiteWinLossSummary, result);
            Assert.True(equal);
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

        public List<SiteWinLossSummary> CreateSiteWinLossSummaries()
        {
            List<SiteWinLossSummary> result = new List<SiteWinLossSummary>();
            result.Add(CreateExpectedGrandTotal());
            return result;
        }

        public WinLossModel CreateExpectedCaculateSum()
        {
            var mainTotal = WinLossFactory.CreateWinLoss(1, "Main Bet Types Total", 20, 20, 20, 20, 20, 20, 0, 0, 20, 20, 20m / 20, 20m / 20);
            var otherTotal = WinLossFactory.CreateWinLoss(0, "Other Bet Types Total", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            List<WinLoss> rM = new List<WinLoss>();
            rM.Add(WinLossFactory.CreateWinLoss(1, "Deposit", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
            var grandTotal = CreateExpectedGrandTotal();
            return new WinLossModel
            {
                SiteWinLossSummaries = null,
                GrandTotal = grandTotal,
                MainTotal = mainTotal,
                OtherTotal = otherTotal,
                RM = rM
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

        public List<RawWinLoss> CreateFakeRawWinLossSummary()
        {
            List<RawWinLoss> result = new List<RawWinLoss>();
            result.Add(SoccerWinLossFactory.CreateRawWinLoss(1, "Grand Total", "Credit", true, 10, 10, 10, 10, 10, 10, 10, 10));
            result.Add(SoccerWinLossFactory.CreateRawWinLoss(1, "Grand Total", "Deposit", true, 10, 10, 10, 10, 10, 10, 10, 10));
            return result;
        }

        private bool AreTwoSoccerBetTypeWinLossSummaryEqual(WinLossModel expected, WinLossModel model)
        {
            return Comparison.AreEqual(expected.OtherTotal, model.OtherTotal)
                && Comparison.AreEqual(expected.MainTotal, model.MainTotal)
                && Comparison.AreEqual(expected.GrandTotal, model.GrandTotal)
                && Comparison.AreEqual(expected.RM, model.RM);
        }

        private bool AreTwoCalculateSiteWinLossSummaryEqual(WinLossModel expected, WinLossModel model)
        {
            return Comparison.AreEqual(expected.SiteWinLossSummaries, model.SiteWinLossSummaries);
        }
    }
}
