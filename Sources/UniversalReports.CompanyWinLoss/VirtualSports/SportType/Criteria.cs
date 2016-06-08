using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-VirtualSports-SportType-{Source}";
        }
    }
}