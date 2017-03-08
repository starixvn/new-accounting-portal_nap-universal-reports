using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.BetCount.Model
{
    public class Criteria : CriteriaBase
    {
        public override string GetSettingKey() => "Punter-Main-SelTopPunterSummary";

        public override bool IsValid() => true;
    }
}