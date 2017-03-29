using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Casino.Product
{
    public class Criteria : WinLossCriteria
    {
        public int CasinoType { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Casino-Product-{Source}"; 
    }
}