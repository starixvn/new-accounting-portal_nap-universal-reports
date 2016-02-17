using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.LiveCasino.BetType;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.LiveCasino.BetType
{
    [TestFixture]
    [Category("Live Casino")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_Should_Return_Right_BetTypeWinLoss()
        {
            // Arrange
            var expectedProductDetailWinLoss = CreateExpectedBetTypeWinLoss();
            var rawService = Substitute.For<RawWinLossService>();
            var calculationService = new CalculationServiceImp();
            var fakeRawWinLoss = CreateFakeRawWinLoss();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeRawWinLoss);

            // Act
            var service = new ServiceImp(rawService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal1 = WinLossComparision.AreTwoSiteWinLossSummaryListEqual(result.BetTypes, expectedProductDetailWinLoss.BetTypes);
            var equal2 = WinLossComparision.AreTwoSiteWinLossSummaryEqual(result.GrandTotal, expectedProductDetailWinLoss.GrandTotal);
            Assert.IsTrue(equal1);
            Assert.IsTrue(equal2);
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            var sliPartyBaccaratCreditWinLoss = WinLossFactory.CreateRawWinLoss(1101, "Party Baccarat", "Credit", 100, 110, 10, 300, 600, 600, 1000);
            var sliPartyBaccaratDepositWinLoss = WinLossFactory.CreateRawWinLoss(1101, "Party Baccarat", "Deposit", 110, 120, 11, 100, 300, 400, 500);

            var sliPartyRouletteCreditWinLoss = WinLossFactory.CreateRawWinLoss(1102, "Party Roulette", "Credit", 100, 110, 10, 300, 600, 600, 1000);
            var sliPartyRouletteDepositWinLoss = WinLossFactory.CreateRawWinLoss(1102, "Party Roulette", "Deposit", 110, 120, 11, 100, 300, 400, 500);

            var sliLiveBaccaratCreditWinLoss = WinLossFactory.CreateRawWinLoss(1103, "Live Baccarat", "Credit", 100, 110, 10, 300, 600, 600, 1000);
            var sliLiveBaccaratDepositWinLoss = WinLossFactory.CreateRawWinLoss(1103, "Live Baccarat", "Deposit", 110, 120, 11, 100, 300, 400, 500);

            return new List<RawWinLoss> {
                sliPartyBaccaratCreditWinLoss,
                sliPartyBaccaratDepositWinLoss,
                sliPartyRouletteCreditWinLoss,
                sliPartyRouletteDepositWinLoss,
                sliLiveBaccaratCreditWinLoss,
                sliLiveBaccaratDepositWinLoss };
        }

        private WinLossModel CreateExpectedBetTypeWinLoss()
        {
            return new WinLossModel
            {
                BetTypes = CreateExpectBetType(),
                GrandTotal = CreateExpectedGrandTotal()
            };
        }

        private List<SiteWinLossSummary> CreateExpectBetType()
        {
            var partyBaccarat = CreateExpectBetType(1101, "Party Baccarat");
            var partyRoulette = CreateExpectBetType(1102, "Party Roulette");
            var liveBaccarat = CreateExpectBetType(1103, "Live Baccarat");

            return new List<SiteWinLossSummary> { partyBaccarat, partyRoulette, liveBaccarat };
        }

        private SiteWinLossSummary CreateExpectBetType(int betType, string betTypeName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(betType, "Credit", 100, 110, 10, 300, 600, -300, 600, 1000, 0.5m, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(betType, "Deposit", 110, 120, 11, 100, 300, -200, 400, 500, 0.25m, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(betType, betTypeName, 210, 230, 21, 400, 900, -500, 1000, 1500, 0.4m, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(1101, "Credit", 300, 330, 30, 900, 1800, -900, 1800, 3000, 0.5m, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(1101, "Deposit", 330, 360, 33, 300, 900, -600, 1200, 1500, 0.25m, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(1101, "Grand Total", 630, 690, 63, 1200, 2700, -1500, 3000, 4500, 0.4m, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
