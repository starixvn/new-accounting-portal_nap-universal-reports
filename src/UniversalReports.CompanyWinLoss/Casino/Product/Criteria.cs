using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Casino.Product
{
    public class Criteria : WinLossCriteria
    {
        public int CasinoType { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Casino-Product-{Source}";
        }
    }
}