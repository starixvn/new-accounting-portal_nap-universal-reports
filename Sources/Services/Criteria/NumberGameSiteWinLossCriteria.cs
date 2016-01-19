using NAP.Reports.CompanyWinLoss.Services.Models;

namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    public class NumberGameSiteWinLossCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public int Site { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new NumberGameSiteWinLossCriteria
            {
                SportType = SportType,
                BetType = BetType,
                IsLive = IsLive,
                Site = Site
            };

            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-NumberGame-Site-{Source}";
        }
    }
}
