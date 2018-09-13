using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.DatabaseTests.TestCases
{
    public static class NormalCriteriaTestCases
    {
        public static ICriteria[] BettransCriteriaCases => CreateBettransCriteriaTestCase();
        public static ICriteria[] WarehouseCriteriaCases => CreateWarehouseCriteriaTestCase();

        private static ICriteria[] CreateBettransCriteriaTestCase()
        {
            var criteriaList = CreateCriteriaTestCase();

            return criteriaList
                .Select(i => WinLossCriteriaFactory.CreateBetTransCriteria(i))
                .ToArray();
        }

        private static ICriteria[] CreateWarehouseCriteriaTestCase()
        {
            var criteriaList = CreateCriteriaTestCase();

            return criteriaList
                .Select(i => WinLossCriteriaFactory.CreateWarehouseCriteria(i))
                .ToArray();
        }

        private static List<WinLossCriteria> CreateCriteriaTestCase()
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
            var otherSportsNewCricketBetTypeCriteria = new OtherSports.NewCricket.Criteria { SportType = 50 };
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
            var soccerMajorMinorLiveCriteria = new Soccer.MajorMinor.Criteria();
            var soccerSumBetTypeCriteria = new Soccer.SumBetType.SumBetTypeCriteria
            {
                IsMajor = true
            };
            var soccerGroupBetTypeCriteria = new Soccer.GroupBetType.GroupBetTypeCriteria
            {
                IsMajor = true,
                IsLive = 2
            };

            var sportsbookSiteCriteria = new Sportsbook.Site.Criteria
            {
                SportType = 1,
                BetType = 1,
                Site = "Credit",
                IsHedge = 2,
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

            var virtualSportsBetradarBetTypeCriteria = new VirtualSportsBetradar.BetType.Criteria { SportType = 190 };
            var virtualSportsBetradarSportTypeCriteria = new VirtualSportsBetradar.SportType.Criteria();
            var virtualSportsBetradarMatchDetailCriteria = new VirtualSportsBetradar.MatchDetail.Criteria
            {
                BetType = 2700,
                SportType = 190
            };
            var virtualSportsBetradarSiteCriteria = new VirtualSportsBetradar.Site.Criteria
            {
                SportType = 190,
                BetType = 2700,
                Site = "Credit"
            };

            var colossusBetBetTypeCriteria = new ColossusBet.BetType.Criteria();
            var colossusBetSiteCriteria = new ColossusBet.Site.Criteria
            {
                Site = "Deposit",
                BetType = 18000,
                IsFreePlay = true
            };

            var pokerGamesBetTypeCriteria = new PokerGames.BetType.Criteria { ProductId = 33 };
            var pokerGamesSiteCriteria = new PokerGames.Site.Criteria
            {
                Site = "Deposit",
                BetType = 18000,
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
                metricGamingLiveNonLiveCriteria,
                metricGamingBetTypeCriteria,
                metricGamingSiteCriteria,
                numberGameMatchDetailCriteria,
                otherSportsBetTypeCriteria,
                otherSportsNewCricketBetTypeCriteria,
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
                soccerMajorMinorLiveCriteria,
                soccerSumBetTypeCriteria,
                soccerGroupBetTypeCriteria,
                sportsbookSiteCriteria,
                universalSportTypeCriteria,
                universalBetTypeCriteria,
                universalSiteCriteria,
                virtualSportsBetTypeCriteria,
                virtualSportsSportTypeCriteria,
                virtualSportsSiteCriteria,
                virtualSportsRacingDetailCriteria,
                fishingWorldBetTypeCriteria,
                fishingWorldSiteCriteria,
                virtualSportsBetradarSportTypeCriteria,
                virtualSportsBetradarBetTypeCriteria,
                virtualSportsBetradarMatchDetailCriteria,
                virtualSportsBetradarSiteCriteria,
                colossusBetBetTypeCriteria,
                colossusBetSiteCriteria,
                pokerGamesBetTypeCriteria,
                pokerGamesSiteCriteria
            };
            return criteriaList;
        }
    }
}