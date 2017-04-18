using Epplus.Mapper.Annotations;
using System;

namespace UniversalReports.PlayForFun.Summary.Model
{
    public class SummaryExcelModel
    {
        [Cell("A1")]
        public DateTime Date { get; set; }

        [Cell("B1")]
        public int PlayerCount { get; set; }

        [Cell("C1")]
        public decimal Turnover { get; set; }

        [Cell("D1")]
        public decimal WinLoss { get; set; }

        [Cell("E1")]
        public int BetCount { get; set; }
    }
}
