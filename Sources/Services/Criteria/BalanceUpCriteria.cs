using Fanex.Data.Repository;

namespace NAP.Reports.CompanyWinLoss.Services.Criteria
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
