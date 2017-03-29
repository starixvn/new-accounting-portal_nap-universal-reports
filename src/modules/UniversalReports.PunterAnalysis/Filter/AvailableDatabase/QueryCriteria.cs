using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.Filter.AvailableDatabase
{
    public class QueryCriteria : CriteriaBase
    {
        public int TaskId => 1;

        public override string GetSettingKey() => "Punter-AvailabeDatabaseQuery";

        public override bool IsValid() => true;
    }
}
