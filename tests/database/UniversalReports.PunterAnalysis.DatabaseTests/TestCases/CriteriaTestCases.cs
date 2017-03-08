using System;
using System.Collections.Generic;
using Fanex.Data.Repository;
using SummaryCriteria = UniversalReports.PunterAnalysis.Summary.Model.Criteria;

namespace UniversalReports.PunterAnalysis.DatabaseTests.TestCases
{
    public static class CriteriaTestCases
    {
        static CriteriaTestCases()
        {
            FanexDataConfiguration.Initialize();
            CriteriaCases = CreateTestCases();
        }

        public static ICriteria[] CriteriaCases { get; }

        private static ICriteria[] CreateTestCases()
        {
            var criteria = new SummaryCriteria
            {
                TopRow = 1,
                OrderBy = 1,
                ShortBy = 1,
                PeriodType = 1,
                FromDate = DateTime.Today.AddDays(-1),
                ToDate = DateTime.Today.AddDays(-1),
                Dept = 1,
                LstCombinationID = "100001,100002,100003,100902,118999,200001,200002,200003,200007,200008,200010,200012,200020,1100001,1100002,1100003,1100010,1100020",
            };

            var criteriaList = new List<ICriteria>
            {
                criteria
            };

            return criteriaList.ToArray();
        }
    }
}