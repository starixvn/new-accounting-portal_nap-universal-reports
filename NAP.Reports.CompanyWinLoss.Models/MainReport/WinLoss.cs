
namespace NAP.Reports.CompanyWinLoss.Models.MainReport
{
    public class WinLoss
    {
        public string Tittle { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal CompanyRealIncome { get; set; }

        public decimal CompanyVirtualIncome { get; set; }

        public decimal CompanyVarianceIncome { get; set; }

        public decimal CompanyRealTurnover { get; set; }

        public decimal CompanyVirtualTurnover { get; set; }

        public decimal RealMargin { get; set; }

        public decimal VirtualMargin { get; set; }
    }
}
