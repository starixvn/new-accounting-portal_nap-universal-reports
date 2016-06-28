using Fanex.Data.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.DatabaseTests.Repository
{
    public class MatchDetailDynamicRepositoryTests
    {
        private static ICriteria[] criteriaList = CreateTestCases();

        [Test]
        [TestCaseSource("criteriaList")]
        [Category("RepositoryTests")]
        public void Fetch_Successful(ICriteria criteria)
        {
            var repository = new DynamicRepository();
            repository.Fetch<CompanyWinLoss.Common.MatchDetail.RawWinLoss>(criteria);
        }

        private static ICriteria[] CreateTestCases()
        {
            var metricGamingMatchDetailCriteria = new CompanyWinLoss.MetricGaming.MatchDetail.Criteria
            {
                BetType = 1,
                IsLive = 2
            };
            var sportsbookMatchDetailCriteria = new CompanyWinLoss.Sportsbook.MatchDetail.Criteria
            {
                BetType = 1,
                SportType = 1,
                IsLive = 2,
                IsHedge = false
            };
            var sportsbookOutrightMatchDetailCriteria = new CompanyWinLoss.Sportsbook.OutrightMatchDetail.Criteria
            {
                SportType = 1
            };

            var virtualSportsSportsbookDetailCriteria = new CompanyWinLoss.VirtualSports.SportsbookDetail.Criteria
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
