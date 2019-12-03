namespace UniversalReports.PunterAnalysis.BetTypeGroup.Model
{
    public class BetTypeGroupModel
    {
        public int LeagueGroupId { get; set; }

        public string LeagueGroupName { get; set; }

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin => Turnover == 0 ? 0 : WinLoss / Turnover;

        public int BetCount { get; set; }

        public static BetTypeGroupModel operator +(BetTypeGroupModel a, BetTypeGroupModel b)
        {
            return new BetTypeGroupModel
            {
                LeagueGroupId = 0,
                LeagueGroupName = string.Empty,
                WinLoss = a.WinLoss + b.WinLoss,
                BetCount = a.BetCount + b.BetCount,
                Turnover = a.Turnover + b.Turnover
            };
        }
    }
}