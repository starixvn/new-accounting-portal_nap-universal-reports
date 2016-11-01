using Fanex.Data.Repository;

namespace UniversalReports.NG2Statistic.Filter
{
    public class SportCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "NG2-Statistics-Sports";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
