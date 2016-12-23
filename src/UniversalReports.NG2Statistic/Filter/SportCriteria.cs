using Fanex.Data.Repository;

namespace UniversalReports.NG2Statistic.Filter
{
    public class SportCriteria : CriteriaBase
    {
        public override string GetSettingKey() => "NG2-Statistics-Sports"; 

        public override bool IsValid() => true;
    }
}
