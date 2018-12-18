namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class VirtualSportsBetradarSiteCriteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public string Site { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-VirtualSportsBetradar-Site-{Source}";
    }
}