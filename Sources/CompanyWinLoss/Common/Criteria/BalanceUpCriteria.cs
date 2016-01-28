using Fanex.Data.Repository;

namespace UniversalReports.CompanyWinLoss.Common.Criteria
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
