using Fanex.Data.Repository;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class SiteCriteria : CriteriaBase
    {
        public override string GetSettingKey() => $"SMAWinLoss-SiteSel";

        public override bool IsValid() => true;
    }
}