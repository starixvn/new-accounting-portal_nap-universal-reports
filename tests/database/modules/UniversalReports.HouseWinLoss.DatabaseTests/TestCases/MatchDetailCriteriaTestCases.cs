using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.MetricGaming.MatchDetail;

namespace UniversalReports.HouseWinLoss.DatabaseTests.TestCases
{
    public static class MatchDetailCriteriaTestCases
    {
        public static ICriteria[] CriteriaCases
        {
            get
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

                var result = new List<WinLossCriteria>
            {
                metricGamingMatchDetailCriteria,
                sportsbookMatchDetailCriteria,
                sportsbookOutrightMatchDetailCriteria,
                virtualSportsSportsbookDetailCriteria,
                bullfightingMatchDetailCriteria
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
}