using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.LiveCasino
{
    [TestFixture]
    [Category("Live Casino")]
    public class GameTypeSummaryWinLossByProductServiceUnitTests
    {
        [Test]
        public void Should_Return_Right_GameTypeSummaryWinLossByProduct()
        {
            // Arrange
            var expectedGameTypeSummaryWinLossByProduct = CreateExpectedGameTypeSummaryWinLossByProduct();
            var rawService = Substitute.For<RawService>();
            var calculationService = Substitute.For<CalculationService>();
            var fakeRawWinLoss = CreateFakeRawWinLoss();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeRawWinLoss);

            // Act
            var service = new GameTypeSummaryWinLossByProductService(rawService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal1 = WinLossComparision.AreTwoSiteWinLossSummaryListEqual(result.GameTypes, expectedGameTypeSummaryWinLossByProduct.GameTypes);
            var equal2 = WinLossComparision.AreTwoSiteWinLossSummaryEqual(result.GrandTotal, expectedGameTypeSummaryWinLossByProduct.GrandTotal);
            Assert.IsTrue(equal1);
            Assert.IsTrue(equal2);
        }

        private GameTypeSummaryWinLossByProduct CreateExpectedGameTypeSummaryWinLossByProduct()
        {
            return new GameTypeSummaryWinLossByProduct
            {
                GameTypes = CreateExpectGameTypes(),
                GrandTotal = CreateExpectedGrandTotal()
            };
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

        private List<SiteWinLossSummary> CreateExpectGameTypes()
        {
            var partyBaccarat = CreateExpectedGameType(1101, "Party Baccarat");
            var partyRoulette = CreateExpectedGameType(1102, "Party Roulette");
            var liveBaccarat = CreateExpectedGameType(1103, "Live Baccarat");

            return new List<SiteWinLossSummary> { partyBaccarat, partyRoulette, liveBaccarat };
        }

        private SiteWinLossSummary CreateExpectedGameType(int gameTypeId, string gameTypeName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(gameTypeId, "Credit", 100, 110, 10, 300, 600, -300, 600, 1000, 0.5m, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(gameTypeId, "Deposit", 110, 120, 11, 100, 300, -200, 400, 500, 0.25m, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(gameTypeId, gameTypeName, 210, 230, 21, 400, 900, -500, 1000, 1500, 0.25m, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private SiteWinLossSummary CreateExpectedGrandTotal()
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(0, "Credit", 300, 310, 30, 900, 1800, -900, 1800, 3000, 0.5m, 0.6m);
            var depositWinLoss = WinLossFactory.CreateWinLoss(0, "Deposit", 330, 360, 33, 300, 900, -600, 1200, 1500, 0.25m, 0.6m);
            var totalWinLoss = WinLossFactory.CreateWinLoss(0, "All Total", 630, 670, 63, 1200, 2700, -1500, 3000, 4500, 0.4m, 0.6m);

            return new SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }

    internal class GameTypeSummaryWinLossByProductService
    {
        private CalculationService calculationService;
        private RawService rawService;

        public GameTypeSummaryWinLossByProductService(RawService rawService, CalculationService calculationService)
        {
            this.rawService = rawService;
            this.calculationService = calculationService;
        }

        internal GameTypeSummaryWinLossByProduct Query(WinLossCriteria winLossCriteria)
        {
            return new GameTypeSummaryWinLossByProduct();
        }
    }

    internal class GameTypeSummaryWinLossByProduct
    {
        public List<SiteWinLossSummary> GameTypes { get; set; }

        public SiteWinLossSummary GrandTotal { get; set; }
    }
}
