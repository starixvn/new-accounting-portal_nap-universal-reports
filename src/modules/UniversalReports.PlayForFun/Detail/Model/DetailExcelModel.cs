using Epplus.Mapper.Annotations;
using System;

namespace UniversalReports.PlayForFun.Detail.Model
{
    public class DetailExcelModel
    {
        [Cell("A1")]
        public DateTime Date { get; set; }

        [Cell("B1")]
        public string GroupHeadline { get; set; }

        [Cell("C1")]
        public string Site { get; set; }

        [Cell("D1")]
        public string Currency { get; set; }

        [Cell("E1")]
        public string Super { get; set; }

        [Cell("F1")]
        public string Username { get; set; }

        [Cell("G1")]
        public int CustId { get; set; }

        [Cell("H1")]
        public string Product { get; set; }

        [Cell("I1")]
        public string Status { get; set; }

        [Cell("J1")]
        public string MemberRequest { get; set; }

        [Cell("K1")]
        public decimal Turnover { get; set; }

        [Cell("L1")]
        public decimal WinLoss { get; set; }

        [Cell("M1")]
        public int BetCount { get; set; }
    }
}
