using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.DatabaseTests.TestCases
{
    public static class NormalCriteriaTestCases
    {
        public static ICriteria[] CriteriaCases => CreateCriteriaTestCase();

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2101:MethodMustNotContainMoreLinesThan",
            Justification = "Reviewed. Suppression is OK here.")]
        private static ICriteria[] CreateCriteriaTestCase()
        {
            var betTradeBetTypeCriteria = new Bettrade.BetType.Criteria();
            var betTradeSiteCriteria = new Bettrade.Site.Criteria { Site = "Deposit" };

            var cashOutBetTypeCriteria = new CashOut.BetType.Criteria();
            var cashOutSiteCriteria = new CashOut.Site.Criteria { Site = "Deposit" };

            var casinoBetTypeCriteria = new Casino.BetType.Criteria { CasinoProductId = 6 };
            var casinoProductCriteria = new Casino.Product.Criteria { CasinoType = 1 };
            var casinoSiteCriteria = new Casino.Site.Criteria
            {
                BetType = 2101,
                Site = "Credit"
            };

            var metricGamingBetTypeCriteria = new MetricGaming.BetType.Criteria { IsLive = 2 };
            var metricGamingLiveNonLiveCriteria = new MetricGaming.LiveNonLive.Criteria();
            var metricGamingSiteCriteria = new MetricGaming.Site.Criteria
            {
                BetType = 1,
                Site = "Credit",
                IsLive = 2
            };

            var numberGameMatchDetailCriteria = new NumberGame.MatchDetail.Criteria
            {
                BetType = 81,
                IsLive = true
            };

            var otherSportsBetTypeCriteria = new OtherSports.BetType.Criteria { SportType = 99 };
            var otherSportsLiveNonLiveCriteria = new OtherSports.LiveNonLive.Criteria();
            var otherSportsSportTypeCriteria = new OtherSports.SportType.Criteria();

            var parlayBetTypeCriteria = new Parlay.BetType.Criteria();
            var parlaySiteCriteria = new Parlay.Site.Criteria { Site = "Credit" };

            var productCriteria = new Products.Criteria();

            var racingBetTypeCriteria = new Racing.BetType.Criteria { SportType = 151 };
            var racingSportTypeCriteria = new Racing.SportType.Criteria();
            var racingSiteCriteria = new Racing.Site.Criteria
            {
                SportType = 151,
                BetType = 31,
                Site = "Credit"
            };
            var racingMatchDetailCriteria = new Racing.MatchDetail.Criteria
            {
                BetType = 31,
                SportType = 151
            };

            var soccerBetTypeCriteria = new Soccer.BetType.BetTypeCriteria
            {
                IsLive = 2,
                IsMajor = true
            };
            var soccerLiveNonLiveCriteria = new Soccer.LiveNonLive.Criteria();
            var soccerMajorMinorCriteria = new Soccer.MajorMinor.Criteria
            {
                IsLive = 2
            };

            var sportsbookSiteCriteria = new Sportsbook.Site.Criteria
            {
                SportType = 1,
                BetType = 1,
                Site = "Credit",
                IsHedge = false,
                IsLive = 2
            };

            var universalSportTypeCriteria = new Universal.SportType.Criteria { ProductId = 23 };
            var universalBetTypeCriteria = new Universal.BetType.Criteria { ProductId = 7 };
            var universalSiteCriteria = new Universal.Site.Criteria
            {
                Site = "Deposit",
                BetType = 18000
            };

            var virtualSportsBetTypeCriteria = new VirtualSports.BetType.Criteria { SportType = 180 };
            var virtualSportsSportTypeCriteria = new VirtualSports.SportType.Criteria();
            var virtualSportsSiteCriteria = new VirtualSports.Site.Criteria
            {
                SportType = 180,
                BetType = 1203,
                Site = "Credit"
            };
            var virtualSportsRacingDetailCriteria = new VirtualSports.RacingDetail.Criteria
            {
                BetType = 1231,
                SportType = 181
            };

            var fishingWorldBetTypeCriteria = new FishingWorld.BetType.Criteria();
            var fishingWorldSiteCriteria = new FishingWorld.Site.Criteria
            {
                Site = "Deposit",
                BetType = 1101
            };

            var criteriaList = new List<WinLossCriteria>
                {
                    betTradeBetTypeCriteria,
                    betTradeSiteCriteria,
                cashOutBetTypeCriteria,
                cashOutSiteCriteria,
                    casinoBetTypeCriteria,
                    casinoProductCriteria,
                    casinoSiteCriteria,
                    metricGamingBetTypeCriteria,
                    metricGamingLiveNonLiveCriteria,
                    metricGamingSiteCriteria,
                    numberGameMatchDetailCriteria,
                    otherSportsBetTypeCriteria,
                    otherSportsLiveNonLiveCriteria,
                    otherSportsSportTypeCriteria,
                    parlayBetTypeCriteria,
                    parlaySiteCriteria,
                    productCriteria,
                    racingBetTypeCriteria,
                    racingSportTypeCriteria,
                    racingSiteCriteria,
                    racingMatchDetailCriteria,
                    soccerBetTypeCriteria,
                    soccerLiveNonLiveCriteria,
                    soccerMajorMinorCriteria,
                    sportsbookSiteCriteria,
                    universalSportTypeCriteria,
                    universalBetTypeCriteria,
                    universalSiteCriteria,
                    virtualSportsBetTypeCriteria,
                    virtualSportsSportTypeCriteria,
                    virtualSportsSiteCriteria,
                    virtualSportsRacingDetailCriteria,
                    fishingWorldBetTypeCriteria,
                    fishingWorldSiteCriteria
                };

            return criteriaList
                .Select(i => new[]
                {
                WinLossCriteriaFactory.CreateBetTransCriteria(i),
                WinLossCriteriaFactory.CreateBetTrans14Criteria(i),
                WinLossCriteriaFactory.CreateWarehouseCriteria(i)
                })
                .SelectMany(l => l)
                .ToArray();
        }
    }
}