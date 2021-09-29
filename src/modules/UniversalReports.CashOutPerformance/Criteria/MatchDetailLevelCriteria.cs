using Fanex.Data.Repository;
using System;

namespace UniversalReports.CashOutPerformance.Criteria
{
    public class MatchDetailLevelCriteria : CriteriaBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Sites { get; set; }

        public string LeagueGroupIDs { get; set; }

        public byte LiveIndicator { get; set; }

        public int SportType { get; set; }

        public int BetType { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public override string GetSettingKey() => "Acc_Rpt_COPerformance_Cust";

        public override bool IsValid() => true;
    }
}