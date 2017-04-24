using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.Performance.BetCount
{
    public class QueryCriteria : CriteriaBase
    {
        public int TaskId => 1;

        public override string GetSettingKey() => "Punter-Performance-BetCount";

        public override bool IsValid() => true;
    }
}
