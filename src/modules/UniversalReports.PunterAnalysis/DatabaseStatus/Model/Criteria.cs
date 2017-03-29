using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.DatabaseStatus.Model
{
    public class Criteria : CriteriaBase
    {
        public int TaskId => 1;

        public override string GetSettingKey() => "Punter-DatabaseReadiness";

        public override bool IsValid() => true;
    }
}