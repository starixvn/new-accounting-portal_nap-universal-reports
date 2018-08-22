using Fanex.Data.Repository;

namespace UniversalReports.ActualMemberBet.Filter
{
    public class CurrencyCriteria : CriteriaBase
    {
        public override string GetSettingKey() => "Actual-Member-Bet-Currency";

        public override bool IsValid() => true;
    }
}
