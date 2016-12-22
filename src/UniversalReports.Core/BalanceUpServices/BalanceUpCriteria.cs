using Fanex.Data.Repository;

namespace UniversalReports.Core.BalanceUpServices
{
    public class BalanceUpCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "GetBalanceUpRange";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}