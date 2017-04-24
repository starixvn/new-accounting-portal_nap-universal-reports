using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.Performance.EventChoice
{
    public class QueryCriteria : CriteriaBase
    {
        public int TaskId => 1;

        public override string GetSettingKey() => "Punter-Performance-EventChoice";

        public override bool IsValid() => true;
    }
}
