using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.Products
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"CN88WinLoss-Products-{Source}";
    }
}