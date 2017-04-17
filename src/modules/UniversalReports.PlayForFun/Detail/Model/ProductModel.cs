namespace UniversalReports.PlayForFun.Detail.Model
{
    public class DetailModel
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin => Turnover == 0 ? 0 : WinLoss / Turnover;

        public int BetCount { get; set; }

        public static DetailModel operator +(DetailModel a, DetailModel b)
        {
            return new DetailModel
            {
                Username = string.Empty,
                WinLoss = a.WinLoss + b.WinLoss,
                BetCount = a.BetCount + b.BetCount,
                Turnover = a.Turnover + b.Turnover
            };
        }
    }
}