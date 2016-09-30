namespace UniversalReports.NG2Statistic.Data.UserName
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