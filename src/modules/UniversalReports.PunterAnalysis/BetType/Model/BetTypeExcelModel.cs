using UniversalReports.EpplusTemplate.Annotations;

namespace UniversalReports.PunterAnalysis.BetType.Model
{
    public class BetTypeExcelModel
    {
        [Cell("A1")]
        public string BetTypeName { get; set; }

        [Cell("B1")]
        public decimal NonLiveWinLoss { get; set; }

        [Cell("C1")]
        public decimal NonLiveTurnover { get; set; }

        [Cell("D1")]
        public decimal NonLiveMargin { get; set; }

        [Cell("E1")]
        public int NonLiveBetCount { get; set; }

        [Cell("F1")]
        public decimal LiveWinLoss { get; set; }

        [Cell("G1")]
        public decimal LiveTurnover { get; set; }

        [Cell("H1")]
        public decimal LiveMargin { get; set; }

        [Cell("I1")]
        public int LiveBetCount { get; set; }

        [Cell("J1")]
        public decimal WinLoss { get; set; }

        [Cell("K1")]
        public decimal Turnover { get; set; }

        [Cell("L1")]
        public decimal Margin { get; set; }

        [Cell("M1")]
        public int BetCount { get; set; }
    }
}