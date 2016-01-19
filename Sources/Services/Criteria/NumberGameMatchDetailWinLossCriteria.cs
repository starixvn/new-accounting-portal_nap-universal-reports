using NAP.Reports.CompanyWinLoss.Services.Models;

namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    public class NumberGameMatchDetailWinLossCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public bool IsLive { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new NumberGameMatchDetailWinLossCriteria
            {
                SportType = SportType,
                BetType = BetType,
                IsLive = IsLive,
            };

            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-NumberGame-MatchDetail-{Source}";
        }
    }
}
