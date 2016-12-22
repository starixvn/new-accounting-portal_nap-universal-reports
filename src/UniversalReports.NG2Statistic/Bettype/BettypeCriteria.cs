using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class BettypeCriteria : NG2CriteriaBase
    {
        public bool IsDrillDown { get; set; }

        public override string GetSettingKey()
        {
            return "NG2-Statistics-Bettype";
        }
    }
}