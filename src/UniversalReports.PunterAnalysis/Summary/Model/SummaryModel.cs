namespace UniversalReports.PunterAnalysis.Summary.Model
{
    public class SummaryModel
    {
        public string UserName { get; set; } = string.Empty;

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin
        {
            get
            {
                return Turnover == 0 ? 0 : WinLoss / Turnover;
            }
        }

        public int BetCount { get; set; }

        public static SummaryModel operator +(SummaryModel object1, SummaryModel object2)
        {
            return new SummaryModel
            {
                WinLoss = object1.WinLoss + object2.WinLoss,
                Turnover = object1.Turnover + object2.Turnover,
                BetCount = object1.BetCount + object2.BetCount,
            };
        }
    }
}