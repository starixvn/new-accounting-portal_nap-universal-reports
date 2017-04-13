namespace UniversalReports.PunterAnalysis.Summary.Model
{
    public class SummaryModel
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin => Turnover == 0 ? 0 : WinLoss / Turnover;

        public int BetCount { get; set; }

        public static SummaryModel operator +(SummaryModel a, SummaryModel b)
        {
            return Add(a, b);
        }

        public static SummaryModel Add(SummaryModel a, SummaryModel b)
        {
            return new SummaryModel
            {
                Username = string.Empty,
                WinLoss = a.WinLoss + b.WinLoss,
                BetCount = a.BetCount + b.BetCount,
                Turnover = a.Turnover + b.Turnover
            };
        }

        public static bool operator ==(SummaryModel a, SummaryModel b)
        {
            return a.BetCount == b.BetCount
                && a.WinLoss == b.WinLoss
                && a.Turnover == b.Turnover
                && a.Username == b.Username
                && a.CustId == b.CustId;
        }

        public static bool operator !=(SummaryModel a, SummaryModel b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            var good = obj as SummaryModel;
            return obj != null && this == good;
        }
    }
}