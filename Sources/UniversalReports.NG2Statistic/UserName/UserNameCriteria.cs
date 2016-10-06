using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.UserName
{
    public class UserNameCriteria : CommonCriteria
    {
        public bool IsDrillDown { get; set; }

        public override string GetSettingKey()
        {
            return "NG2-Statistics-UserName";
        }
    }
}