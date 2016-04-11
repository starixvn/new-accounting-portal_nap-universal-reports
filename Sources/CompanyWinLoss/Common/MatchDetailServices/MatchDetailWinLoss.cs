namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public class MatchDetailWinLoss
    {
        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public bool IsNeutral { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal VirtualIncome { get; set; }

        public decimal VarianceIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal VirtualTurnover { get; set; }

        public decimal Margin { get; set; }
    }
}