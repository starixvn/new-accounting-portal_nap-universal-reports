using Epplus.Mapper.Annotations;

namespace UniversalReports.PunterAnalysis.Summary.Model
{
    public class SummaryExcelModel
    {
        [Cell("A8")]
        public string Username { get; set; }

        [Cell("B8")]
        public decimal WinLoss { get; set; }

        [Cell("C8")]
        public decimal Turnover { get; set; }

        [Cell("D8")]
        public decimal Margin { get; set; }

        [Cell("E8")]
        public int BetCount { get; set; }
    }
}
