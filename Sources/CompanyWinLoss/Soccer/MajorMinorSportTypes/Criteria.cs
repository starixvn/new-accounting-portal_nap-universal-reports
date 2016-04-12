namespace UniversalReports.CompanyWinLoss.Soccer.MajorMinorSportTypes
{
    using UniversalReports.CompanyWinLoss.Common.Criteria;
    using UniversalReports.CompanyWinLoss.Common.Models;

    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria
            {
                IsLive = IsLive
            };
            newCriteria.Update(source);

            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Soccer-Major-Minor-{Source}";
        }
    }
}
