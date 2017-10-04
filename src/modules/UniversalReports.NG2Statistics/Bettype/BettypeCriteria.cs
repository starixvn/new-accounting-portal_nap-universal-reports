using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    public class BettypeCriteria : NG2CriteriaBase
    {
        public bool IsDrillDown { get; set; }

        public override string GetSettingKey() => "NG2-Statistics-Bettype";
    }
}