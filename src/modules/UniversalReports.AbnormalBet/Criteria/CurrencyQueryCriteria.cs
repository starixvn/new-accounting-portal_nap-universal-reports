using Fanex.Data.Repository;

namespace UniversalReports.AbnormalBet.Criteria
{
    public class CurrencyQueryCriteria : CriteriaBase
    {
        public override bool IsValid() => true;

        public override string GetSettingKey() => $"Acc_Rpt_AbnormalBet_CurrencySel";
    }
}