using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Soccer.MajorMinor
{
    public class Criteria : WinLossCriteria
    {
        public int IsLive { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Soccer-Major-Minor-{Source}";
        }
    }
}
