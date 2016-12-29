using Fanex.Data.Repository;

namespace UniversalReports.Core.BalanceUpServices
{
    public class BalanceUpCriteria : CriteriaBase
    {
        public override string GetSettingKey() => "GetBalanceUpRange";

        public override bool IsValid() => true;
    }
}