using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-VirtualSports-BetType-{Source}";
        }
    }
}