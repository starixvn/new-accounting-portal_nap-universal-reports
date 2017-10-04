using System;
using Epplus.Mapper.Annotations;

namespace UniversalReports.PlayForFun.Summary.Model
{
    public class SummaryExcelModel
    {
        [Cell("A4")]
        public DateTime Date { get; set; }

        [Cell("B4")]
        public int PlayerCount { get; set; }

        [Cell("C4")]
        public decimal Turnover { get; set; }

        [Cell("D4")]
        public decimal WinLoss { get; set; }

        [Cell("E4")]
        public int BetCount { get; set; }
    }
}