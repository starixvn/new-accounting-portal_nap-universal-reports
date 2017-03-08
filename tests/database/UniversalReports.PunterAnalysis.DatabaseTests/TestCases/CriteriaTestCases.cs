using Fanex.Data.Repository;
using System;
using System.Collections.Generic;
using AssociatedAccountCriteria = UniversalReports.PunterAnalysis.AssociatedAccount.Model.Criteria;
using BetCountCriteria = UniversalReports.PunterAnalysis.BetCount.Model.Criteria;
using BetTypeCriteria = UniversalReports.PunterAnalysis.BetType.Model.Criteria;
using LeagueCriteria = UniversalReports.PunterAnalysis.League.Model.Criteria;
using SportTypeCriteria = UniversalReports.PunterAnalysis.SportType.Model.Criteria;
using SummaryCriteria = UniversalReports.PunterAnalysis.Summary.Model.Criteria;

namespace UniversalReports.PunterAnalysis.DatabaseTests.TestCases
{
    public static class CriteriaTestCases
    {
        private static ICriteria associatedAccountCriteria = new AssociatedAccountCriteria
        {
            ListCustId = "19575728,2589985,19563966,1455039,18845183"
        };

        private static ICriteria betCountCriteria = new BetCountCriteria
        {
            PeriodType = 3,
            FromDate = new DateTime(2016, 8, 1),
            ToDate = new DateTime(2016, 12, 1),
            CustId = 19575728,
            ListCombinationId = "21802681,21802682,21802683,21901011",
            SportId = 1,
            BetTypeId = 1,
            LiveStatusId = 1
        };

        private static ICriteria betTypeCriteria = new BetTypeCriteria
        {
            PeriodType = 3,
            FromDate = new DateTime(2016, 8, 1),
            ToDate = new DateTime(2016, 12, 1),
            CustId = 19575728,
            ListCombinationId = "21802681,21802682,21802683,21901011",
            SportId = 1,
        };

        private static ICriteria leagueCriteria = new LeagueCriteria
        {
            PeriodType = 3,
            FromDate = new DateTime(2016, 8, 1),
            ToDate = new DateTime(2016, 12, 1),
            CustId = 19575728,
            ListCombinationId = "21802681,21802682,21802683,21901011",
            SportId = 1,
            BetTypeId = 1,
        };

        private static ICriteria sportTypeCriteria = new SportTypeCriteria
        {
            PeriodType = 3,
            FromDate = new DateTime(2016, 8, 1),
            ToDate = new DateTime(2016, 12, 1),
            CustId = 19575728,
            ListCombinationId = "21802681,21802682,21802683,21901011",
        };

        private static ICriteria summaryCriteria = new SummaryCriteria
        {
            TopRow = 10,
            OrderBy = 1,
            SortBy = 2,
            PeriodType = 3,
            FromDate = new DateTime(2016, 8, 1),
            ToDate = new DateTime(2016, 12, 1),
            Depth = 1,
            ListCombinationId = "21802681,21802682,21802683,21901011",
        };

        public static ICriteria[] CriteriaCases => CreateTestCases();

        private static ICriteria[] CreateTestCases()
        {
            var criteriaList = new List<ICriteria>
            {
                associatedAccountCriteria,
                betCountCriteria,
                betTypeCriteria,
                leagueCriteria,
                sportTypeCriteria,
                summaryCriteria
            };

            return criteriaList.ToArray();
        }
    }
}