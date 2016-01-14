namespace NAP.Reports.CompanyWinLoss.Services.Models
{
    public class RawWinLoss
    {
        public string Product { get; set; }

        public string Site { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal VirtualIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal VirtualTurnover { get; set; }
    }
}
