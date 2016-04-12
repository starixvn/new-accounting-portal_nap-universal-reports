namespace UniversalReports.CompanyWinLoss.Soccer.MajorOrMinorBetTypes
{
    using UniversalReports.CompanyWinLoss.Common.Criteria;
    using UniversalReports.CompanyWinLoss.Common.Models;

    public class Criteria : WinLossCriteria
    {
        public bool IsMajor { get; set; }

        public int IsLive { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria
            {
                IsMajor = IsMajor,
                IsLive = IsLive
            };
            newCriteria.Update(source);
            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Soccer-Major-Or-Minor-BetType-{Source}";
        }
    }
}
