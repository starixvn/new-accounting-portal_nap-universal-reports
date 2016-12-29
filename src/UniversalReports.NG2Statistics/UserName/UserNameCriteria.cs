using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.UserName
{
    public class UserNameCriteria : NG2CriteriaBase
    {
        public bool IsDrillDown { get; set; }

        public override string GetSettingKey() => "NG2-Statistics-UserName"; 
    }
}