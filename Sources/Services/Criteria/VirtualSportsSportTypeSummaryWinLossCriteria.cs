using NAP.Reports.CompanyWinLoss.Services.Models;

namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    public class VirtualSportsSportTypeSummaryWinLossCriteria : WinLossCriteria
    {
        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new VirtualSportsSportTypeSummaryWinLossCriteria();
            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-VirtualSports-{Source}";
        }
    }
}
