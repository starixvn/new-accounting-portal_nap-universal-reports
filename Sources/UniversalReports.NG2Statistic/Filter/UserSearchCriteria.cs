using Fanex.Data.Repository;

namespace UniversalReports.NG2Statistic.Filter
{
    public class UserSearchCriteria : CriteriaBase
    {
        public int CustId
        {
            get; set;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerSelUserSearch";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}