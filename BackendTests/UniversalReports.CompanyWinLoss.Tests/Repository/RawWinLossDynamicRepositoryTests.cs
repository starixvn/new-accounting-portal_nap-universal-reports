using Fanex.Data.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.DatabaseTests.Repository
{
    public class RawWinLossDynamicRepositoryTests
    {
        private static ICriteria[] criteriaList = CreateTestCases();

        [Test]
        [TestCaseSource("criteriaList")]
        public void Fetch_Successful(ICriteria criteria)
        {
            var repository = new DynamicRepository();
            repository.Fetch<RawWinLoss>(criteria);
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        private static ICriteria[] CreateTestCases()
        {
            var betTradeBetTypeCriteria = new CompanyWinLoss.Bettrade.BetType.Criteria();

            var casinoBetTypeCriteria = new CompanyWinLoss.Casino.BetType.Criteria { ProductId = 6 };
            var casinoProductCriteria = new CompanyWinLoss.Casino.Product.Criteria { CasinoType = 1 };
            var casinoSiteCriteria = new CompanyWinLoss.Casino.Site.Criteria
            {
                BetType = 2101,
                Site = "Credit"
            };

            var metricGamingBetTypeCriteria = new CompanyWinLoss.MetricGaming.BetType.Criteria { IsLive = 2 };
            var metricGamingLiveNonLiveCriteria = new CompanyWinLoss.MetricGaming.LiveNonLive.Criteria();
            var metricGamingSiteCriteria = new CompanyWinLoss.MetricGaming.Site.Criteria
            {
                BetType = 1,
                Site = "Credit",
                IsLive = 2
            };

            var numberGameBetTypeCriteria = new CompanyWinLoss.NumberGame.BetType.Criteria();
            var numberGameSiteCriteria = new CompanyWinLoss.NumberGame.Site.Criteria
            {
                BetType = 81,
                IsLive = true,
                Site = "Credit"
            };
            var numberGameMatchDetailCriteria = new CompanyWinLoss.NumberGame.MatchDetail.Criteria
            {
                BetType = 81,
                IsLive = true
            };

            var otherSportsBetTypeCriteria = new CompanyWinLoss.OtherSports.BetType.Criteria { SportType = 99 };
            var otherSportsLiveNonLiveCriteria = new CompanyWinLoss.OtherSports.LiveNonLive.Criteria();
            var otherSportsSportTypeCriteria = new CompanyWinLoss.OtherSports.SportType.Criteria();

            var parlayBetTypeCriteria = new CompanyWinLoss.Parlay.BetType.Criteria();
            var parlaySiteCriteria = new CompanyWinLoss.Parlay.Site.Criteria { Site = "Credit" };

            var productCriteria = new CompanyWinLoss.Products.Criteria();

            var racingBetTypeCriteria = new CompanyWinLoss.Racing.BetType.Criteria { SportType = 151 };
            var racingSportTypeCriteria = new CompanyWinLoss.Racing.SportType.Criteria();
            var racingSiteCriteria = new CompanyWinLoss.Racing.Site.Criteria
            {
                SportType = 151,
                BetType = 31,
                Site = "Credit"
            };
            var racingMatchDetailCriteria = new CompanyWinLoss.Racing.MatchDetail.Criteria
            {
                BetType = 31,
                SportType = 151
            };

            var soccerBetTypeCriteria = new CompanyWinLoss.Soccer.BetType.Criteria
            {
                IsLive = 2,
                IsMajor = true
            };
            var soccerLiveNonLiveCriteria = new CompanyWinLoss.Soccer.LiveNonLive.Criteria();
            var soccerMajorMinorCriteria = new CompanyWinLoss.Soccer.MajorMinor.Criteria
            {
                IsLive = 2
            };

            var sportsbookSiteCriteria = new CompanyWinLoss.Sportsbook.Site.Criteria
            {
                SportType = 1,
                BetType = 1,
                Site = "Credit",
                IsHedge = false,
                IsLive = 2
            };

            var universalBetTypeCriteria = new CompanyWinLoss.Universal.BetType.Criteria { ProductId = 7 };
            var universalSiteCriteria = new CompanyWinLoss.Universal.Site.Criteria
            {
                Site = "Deposit",
                BetType = 18000
            };

            var virtualSportsBetTypeCriteria = new CompanyWinLoss.VirtualSports.BetType.Criteria { SportType = 180 };
            var virtualSportsSportTypeCriteria = new CompanyWinLoss.VirtualSports.SportType.Criteria();
            var virtualSportsSiteCriteria = new CompanyWinLoss.VirtualSports.Site.Criteria
            {
                SportType = 180,
                BetType = 1203,
                Site = "Credit"
            };
            var virtualSportsRacingDetailCriteria = new CompanyWinLoss.VirtualSports.RacingDetail.Criteria
            {
                BetType = 1231,
                SportType = 181
            };
            var result = new List<WinLossCriteria>
            {
                betTradeBetTypeCriteria,
                casinoBetTypeCriteria,
                casinoProductCriteria,
                casinoSiteCriteria,
                metricGamingBetTypeCriteria,
                metricGamingLiveNonLiveCriteria,
                metricGamingSiteCriteria,
                numberGameBetTypeCriteria,
                numberGameSiteCriteria,
                otherSportsBetTypeCriteria,
                otherSportsLiveNonLiveCriteria,
                otherSportsSportTypeCriteria,
                parlayBetTypeCriteria,
                parlaySiteCriteria,
                productCriteria,
                racingBetTypeCriteria,
                racingSportTypeCriteria,
                racingSiteCriteria,
                soccerBetTypeCriteria,
                soccerLiveNonLiveCriteria,
                soccerMajorMinorCriteria,
                sportsbookSiteCriteria,
                universalBetTypeCriteria,
                universalSiteCriteria,
                virtualSportsBetTypeCriteria,
                virtualSportsSportTypeCriteria,
                virtualSportsSiteCriteria
            };
            return result
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
