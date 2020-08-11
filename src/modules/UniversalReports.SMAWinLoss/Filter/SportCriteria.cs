using Fanex.Data.Repository;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class SportCriteria : CriteriaBase
    {
        public override string GetSettingKey() => $"SMAWinLoss-SportSel";

        public override bool IsValid() => true;
    }
}