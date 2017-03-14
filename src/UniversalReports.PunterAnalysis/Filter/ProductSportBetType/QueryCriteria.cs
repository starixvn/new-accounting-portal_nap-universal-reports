using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.Filter.ProductSportBetType
{
    public class QueryCriteria : CriteriaBase
    {
        public bool IsSb => false;

        public override string GetSettingKey() => "Punter-ProductSportBetTypeQuery";

        public override bool IsValid() => true;
    }
}
