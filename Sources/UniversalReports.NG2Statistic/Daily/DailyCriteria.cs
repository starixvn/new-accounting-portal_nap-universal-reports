using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.Daily
{
    public class DailyCriteria : NG2CriteriaBase
    {
        public bool IsDrillDown { get; set; }

        public override string GetSettingKey()
        {
            return "NG2-Statistics-Daily";
        }
    }
}