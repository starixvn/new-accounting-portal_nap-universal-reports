using Fanex.Data.Repository;

namespace UniversalReports.AbnormalBet.Criteria
{
    public class BetTypeQueryCriteria : CriteriaBase
    {
        public string SportId { get; set; }

        public override bool IsValid() => true;

        public override string GetSettingKey() => $"Acc_Rpt_AbnormalBet_BetTypeSel";
    }
}
