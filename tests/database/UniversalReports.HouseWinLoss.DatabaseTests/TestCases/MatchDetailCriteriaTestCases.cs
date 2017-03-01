using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.MetricGaming.MatchDetail;

namespace UniversalReports.HouseWinLoss.DatabaseTests.TestCases
{
    public static class MatchDetailCriteriaTestCases
    {
        static MatchDetailCriteriaTestCases()
        {
            FanexDataConfiguration.Initialize();
            CriteriaCases = CreateTestCases();
        }

        public static ICriteria[] CriteriaCases { get; }

        private static ICriteria[] CreateTestCases()
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

            var result = new List<WinLossCriteria>
            {
                metricGamingMatchDetailCriteria,
                sportsbookMatchDetailCriteria,
                sportsbookOutrightMatchDetailCriteria,
                virtualSportsSportsbookDetailCriteria
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
