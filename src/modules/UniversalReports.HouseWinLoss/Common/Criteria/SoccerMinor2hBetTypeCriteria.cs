namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class SoccerMinor2hBetTypeCriteria : WinLossCriteria
    {
        public int IsLive { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-Soccer-Minor-BetType-{Source}";
    }
}