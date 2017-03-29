using UniversalReports.EpplusTemplate.Annotations;

namespace UniversalReports.PunterAnalysis.Summary.Model
{
    public class SummaryExcelModel
    {
        [Cell("A1")]
        public int CustId { get; set; }

        [Cell("B1")]
        public string Username { get; set; }

        [Cell("C1")]
        public decimal WinLoss { get; set; }

        [Cell("D1")]
        public decimal Turnover { get; set; }

        [Cell("E1")]
        public decimal Margin { get; set; }

        [Cell("F1")]
        public int BetCount { get; set; }
    }
}
