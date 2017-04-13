namespace UniversalReports.PunterAnalysis.League.Model
{
    public class PeriodGroup
    {
        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin => Turnover == 0 ? 0 : WinLoss / Turnover;

        public int BetCount { get; set; }

        public static PeriodGroup operator +(PeriodGroup a, PeriodGroup b)
        {
            return Add(a, b);
        }

        public static PeriodGroup Add(PeriodGroup a, PeriodGroup b)
        {
            return new PeriodGroup
            {
                BetCount = a.BetCount + b.BetCount,
                WinLoss = a.WinLoss + b.WinLoss,
                Turnover = a.Turnover + b.Turnover
            };
        }

        public static bool operator ==(PeriodGroup a, PeriodGroup b)
        {
            return a.BetCount == b.BetCount
                && a.WinLoss == b.WinLoss
                && a.Turnover == b.Turnover;
        }

        public static bool operator !=(PeriodGroup a, PeriodGroup b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            var good = obj as PeriodGroup;
            return obj != null && this == good;
        }
    }
}
