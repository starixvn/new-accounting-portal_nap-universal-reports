namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class WinLoss
    {
        public string FightNo { get; set; }

        public int ArenaId { get; set; }

        //public string ArenaName { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal Margin { get; set; }
    }
}
