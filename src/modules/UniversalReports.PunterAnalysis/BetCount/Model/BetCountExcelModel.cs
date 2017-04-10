using System;
using Epplus.Mapper.Annotations;

namespace UniversalReports.PunterAnalysis.BetCount.Model
{
    public class BetCountExcelModel
    {
        [Cell("A1")]
        public DateTime Date { get; set; }

        [Cell("B1")]
        public int BetCount { get; set; }

        [Cell("C1")]
        public int WinCount { get; set; }

        [Cell("D1")]
        public int DrawCount { get; set; }

        [Cell("E1")]
        public decimal WinLoss { get; set; }
    }
}
