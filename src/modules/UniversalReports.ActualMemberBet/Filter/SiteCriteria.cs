using Fanex.Data.Repository;

namespace UniversalReports.ActualMemberBet.Filter
{
    public class SiteCriteria : CriteriaBase
    {
        public override string GetSettingKey() => "Actual-Member-Bet-Site";

        public override bool IsValid() => true;
    }
}
