namespace UniversalReports.PunterAnalysis.League.Model
{
    public class PeriodGroup
    {
        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin => Turnover == 0 ? 0 : WinLoss / Turnover;

        public int BetCount { get; set; }

        public static PeriodGroup operator +(PeriodGroup firstObject, PeriodGroup secondObject)
        {
            return new PeriodGroup
            {
                BetCount = firstObject.BetCount + secondObject.BetCount,
                WinLoss = firstObject.WinLoss + secondObject.WinLoss,
                Turnover = firstObject.Turnover + secondObject.Turnover
            };
        }
    }
}
