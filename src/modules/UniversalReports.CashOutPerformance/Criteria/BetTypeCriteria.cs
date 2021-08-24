using Fanex.Data.Repository;

namespace UniversalReports.CashOutPerformance.Criteria
{
    public class BetTypeCriteria : CriteriaBase
    {
        public override string GetSettingKey() => "Acc_Rpt_COPerformance_BettypeSel";

        public override bool IsValid() => true;
    }
}