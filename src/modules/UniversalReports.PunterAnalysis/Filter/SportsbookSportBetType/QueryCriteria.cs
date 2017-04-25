using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType
{
    public class QueryCriteria : CriteriaBase
    {
        public override string GetSettingKey() => "Punter-SportsbookSportBetTypeQuery";

        public override bool IsValid() => true;
    }
}
