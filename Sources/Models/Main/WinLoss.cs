namespace NAP.Reports.CompanyWinLoss.Models.Main
{
    public class WinLoss
    {
        public string Title { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal VirtualIncome { get; set; }

        public decimal VarianceIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal VirtualTurnover { get; set; }

        public decimal RealMargin { get; set; }

        public decimal VirtualMargin { get; set; }
    }
}
