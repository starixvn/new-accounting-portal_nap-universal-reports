using Fanex.Data.Repository;
using System;

namespace UniversalReports.CashOutPerformance.Criteria
{
    public class BetTypeLevelCriteria : CriteriaBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string SportBettype { get; set; }

        public string Sites { get; set; }

        public string Leagues { get; set; }

        public string LeagueGroupIDs { get; set; }

        public string GlobalShowTime { get; set; }

        public byte LiveIndicator { get; set; }

        public int SportType { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public override string GetSettingKey() => "Acc_Rpt_COPerformance_BetType";

        public override bool IsValid() => true;
    }
}