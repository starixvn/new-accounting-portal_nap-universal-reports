namespace UniversalReports.HouseWinLoss.Common.MatchDetail3rd
{
    public class RawWinLoss
    {
        public string League { get; set; }

        public string MatchCode { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public static RawWinLoss operator +(RawWinLoss a, RawWinLoss b)
        {
            return new RawWinLoss
            {
                League = string.Empty,
                MatchCode = string.Empty,
                AwayId = 0,
                HomeId = 0,
                SMAWinLoss = a.SMAWinLoss + b.SMAWinLoss,
                MemberWinLoss = a.MemberWinLoss + b.MemberWinLoss,
                Commission = a.Commission + b.Commission,
                RealIncome = a.RealIncome + b.RealIncome,
                RealTurnover = a.RealTurnover + b.RealTurnover,
            };
        }
    }
}
