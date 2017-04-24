using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.Performance.Summary
{
    public class QueryCriteria : CriteriaBase
    {
        public int TaskId => 1;

        public override string GetSettingKey() => "Punter-Performance-Summary";

        public override bool IsValid() => true;
    }
}
