namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public class RawWinLoss
    {
        public string GroupName { get; set; }

        public int GroupId { get; set; }

        public string RowName { get; set; }

        public bool IsLive { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal VirtualIncome { get; set; }

        public decimal VarianceIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal VirtualTurnover { get; set; }
    }
}