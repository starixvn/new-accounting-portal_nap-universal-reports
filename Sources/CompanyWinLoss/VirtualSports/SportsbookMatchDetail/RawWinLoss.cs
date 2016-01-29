namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail
{
    public class RawWinLoss
    {
        public string MatchCode { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal RealTurnover { get; set; }
    }
}
