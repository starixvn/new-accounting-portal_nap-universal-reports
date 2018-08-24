using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.DatabaseTests.TestCases;

namespace UniversalReports.HouseWinLoss.DatabaseTests
{
    public class DynamicRepositoryTests
    {
        [Test]
        [Category("RepositoryTests")]
        [TestCaseSource(typeof(MatchDetailCriteriaTestCases), nameof(MatchDetailCriteriaTestCases.BettransCriteriaCases))]
        [TestCaseSource(typeof(MatchDetailCriteriaTestCases), nameof(MatchDetailCriteriaTestCases.WarehouseCriteriaCases))]
        [TestCaseSource(typeof(NormalCriteriaTestCases), nameof(NormalCriteriaTestCases.BettransCriteriaCases))]
        [TestCaseSource(typeof(NormalCriteriaTestCases), nameof(NormalCriteriaTestCases.WarehouseCriteriaCases))]

        public void Fetch_Successful(ICriteria criteria)
        {
            var repository = new DynamicRepository();
            repository.Fetch<WinLossRaw>(criteria);
        }
    }
}