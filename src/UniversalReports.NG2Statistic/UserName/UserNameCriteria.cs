using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.UserName
{
    public class UserNameCriteria : NG2CriteriaBase
    {
        public bool IsDrillDown { get; set; }

        public override string GetSettingKey() => "NG2-Statistics-UserName"; 
    }
}