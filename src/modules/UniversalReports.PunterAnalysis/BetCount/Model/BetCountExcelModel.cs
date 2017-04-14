using Epplus.Mapper.Annotations;

namespace UniversalReports.PunterAnalysis.BetCount.Model
{
    public class BetCountExcelModel
    {
        [Cell("A7")]
        public string Date { get; set; }

        [Cell("B7")]
        public int BetCount { get; set; }

        [Cell("C7")]
        public int WinCount { get; set; }

        [Cell("D7")]
        public int DrawCount { get; set; }

        [Cell("E7")]
        public decimal WinLoss { get; set; }
    }
}
