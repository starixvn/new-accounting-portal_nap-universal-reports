using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.MetricGaming.MatchDetail;

namespace UniversalReports.HouseWinLoss.DatabaseTests.TestCases
{
    public static class MatchDetailCriteriaTestCases
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

        public static List<WinLossCriteria> CreateCriteriaTestCase()
        {

            var metricGamingMatchDetailCriteria = new Criteria
            {
                BetType = 1,
                IsLive = 2
            };
            var sportsbookMatchDetailCriteria = new Sportsbook.MatchDetail.Criteria
            {
                BetType = 1,
                SportType = 1,
                IsLive = 2,
                IsHedge = 2
            };
            var sportsbookOutrightMatchDetailCriteria = new Sportsbook.OutrightMatchDetail.Criteria
            {
                SportType = 1
            };

            var virtualSportsSportsbookDetailCriteria = new VirtualSports.SportsbookDetail.Criteria
            {
                BetType = 1231,
                SportType = 181
            };

            var bullfightingMatchDetailCriteria = new Bullfighting.MatchDetail.Criteria
            {
                BetType = 1004,
                SportType = 207
            };

            var soccerMinorMatchDetailCriteria = new DailyWinLoss2hSoccerMinor.MatchDetail.Criteria
            {
                BetType = 1,
                SportType = 1,
                IsLive = 2,
                IsHedge = 2
            };
            var soccerMinorOutrightMatchDetailCriteria = new DailyWinLoss2hSoccerMinor.OutrightMatchDetail.Criteria
            {
                SportType = 1
            };

            var criteriaList = new List<WinLossCriteria>
                {
                    metricGamingMatchDetailCriteria,
                    sportsbookMatchDetailCriteria,
                    sportsbookOutrightMatchDetailCriteria,
                    virtualSportsSportsbookDetailCriteria,
                    bullfightingMatchDetailCriteria,
                    soccerMinorMatchDetailCriteria,
                    soccerMinorOutrightMatchDetailCriteria
                };


            return criteriaList;
        }
    }
}