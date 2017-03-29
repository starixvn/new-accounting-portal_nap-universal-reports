using Fanex.Data;
using Fanex.Data.Repository;

namespace UniversalReports.NG2Statistics.Filter
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

        [SpParam(SqlParamName = "IsAllowFISearch")]
        public bool IsAllowFinanceUsersSearch
        {
            get; set;
        }

        public override string GetSettingKey() => "NG2-Statistics-UserSearchSuggestion";

        public override bool IsValid() => true;
    }
}