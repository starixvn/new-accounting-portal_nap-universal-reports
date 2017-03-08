namespace UniversalReports.PunterAnalysis.Summary.Model
{
    public class SummaryModel
    {
        public string Username { get; set; }

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin => Turnover == 0 ? 0 : WinLoss / Turnover;

        public int BetCount { get; set; }

        public static SummaryModel operator +(SummaryModel firstObject, SummaryModel secondObject)
        {
            return new SummaryModel
            {
                Username = string.Empty,
                WinLoss = firstObject.WinLoss + secondObject.WinLoss,
                BetCount = firstObject.BetCount + secondObject.BetCount,
                Turnover = firstObject.Turnover + secondObject.Turnover
            };
        }
    }
}