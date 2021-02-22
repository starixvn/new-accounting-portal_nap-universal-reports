using Fanex.Data.Repository;

namespace UniversalReports.SBCustomerPerformanceByDanger.Filter
{
    public class LeagueGroupQueryCriteria : CriteriaBase
    {
        public string SportBettype { get; set; }

        public override string GetSettingKey() => $"Acc_Rpt_SBCustPerfByDangerLevel_LeagueGroupBySportSel";

        public override bool IsValid() => true;
    }
}