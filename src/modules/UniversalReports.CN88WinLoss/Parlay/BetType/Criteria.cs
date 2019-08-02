using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.Parlay.BetType
{
    public class Criteria : WinLossCriteria
    {
        public override string GetSettingKey() => $"CN88WinLoss-Parlay-{Source}";
    }
}