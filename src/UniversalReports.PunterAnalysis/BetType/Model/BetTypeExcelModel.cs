using System;
using UniversalReports.EpplusTemplate.Annotations;

namespace UniversalReports.PunterAnalysis.BetType.Model
{
    public class BetTypeExcelModel
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
