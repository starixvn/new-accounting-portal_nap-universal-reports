using Fanex.Data.Repository;

namespace UniversalReports.NG2Statistic.Filter
{
    public class UserSearchCriteria : CriteriaBase
    {
        public int CustId
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public bool IsAllowFISearch
        {
            get; set;
        }

        public override string GetSettingKey()
        {
            return "NG2-Statistics-UserSearchSuggestion";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}