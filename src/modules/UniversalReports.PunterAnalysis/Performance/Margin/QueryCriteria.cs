using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.Performance.Margin
{
    public class QueryCriteria : CriteriaBase
    {
        public int TaskId => 1;

        public override string GetSettingKey() => "Punter-Performance-Margin";

        public override bool IsValid() => true;
    }
}
