namespace UniversalReports.NG2Statistic.Data.Bettype
{
    public class BettypeCriteria : CommonCriteria
    {
        public bool IsDrillDown { get; set; }

        public override string GetSettingKey()
        {
            return "NG2-Statistics-Bettype";
        }
    }
}