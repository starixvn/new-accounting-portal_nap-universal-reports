namespace UniversalReports.ActualMemberBet.Common
{
    public class BaseModel
    {
        public int BetCount { get; set; }

        public decimal MemberTurnoverRM { get; set; }

        public decimal MemberNetWinLoss { get; set; }

        public decimal HouseRealTurnover { get; set; }

        public decimal HouseVirtualTurnover { get; set; }

        public decimal HouseRealIncome { get; set; }

        public decimal HouseVirtualWinLoss { get; set; }
    }
}
