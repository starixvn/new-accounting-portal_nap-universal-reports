using Fanex.Data.Repository;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class BetFromCriteria : CriteriaBase
    {
        public override string GetSettingKey() => $"SMAWinLoss-BetFromSel";

        public override bool IsValid() => true;
    }
}
