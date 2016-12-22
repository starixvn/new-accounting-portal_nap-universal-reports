using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.MatchDetail;
using UniversalReports.HouseWinLoss.MetricGaming.MatchDetail;

namespace UniversalReports.HouseWinLoss.Tests.Repository
{
    public class MatchDetailDynamicRepositoryTests
    {
        private static readonly ICriteria[] CriteriaList = CreateTestCases();

        [Test]
        [TestCaseSource(nameof(CriteriaList))]
        [Category("RepositoryTests")]
        public void Fetch_Successful(ICriteria criteria)
        {
            var repository = new DynamicRepository();
            repository.Fetch<RawWinLoss>(criteria);
        }

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