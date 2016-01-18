namespace NAP.Reports.CompanyWinLoss.Models
{
    public class WinLoss
    {
        public string GroupName { get; set; }

        public int GroupId { get; set; }

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
