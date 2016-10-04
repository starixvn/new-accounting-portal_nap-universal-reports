using Fanex.Data.Repository;

namespace UniversalReports.Common.BalanceUpServices
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