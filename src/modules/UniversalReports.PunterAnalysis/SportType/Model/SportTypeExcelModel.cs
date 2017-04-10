using Epplus.Mapper.Annotations;

namespace UniversalReports.PunterAnalysis.SportType.Model
{
    public class SportTypeExcelModel
    {
        [Cell("A1")]
        public string SportName { get; set; }

        [Cell("B1")]
        public decimal WinLoss { get; set; }

        [Cell("C1")]
        public decimal Turnover { get; set; }

        [Cell("D1")]
        public decimal Margin { get; set; }

        [Cell("E1")]
        public int BetCount { get; set; }
    }
}
