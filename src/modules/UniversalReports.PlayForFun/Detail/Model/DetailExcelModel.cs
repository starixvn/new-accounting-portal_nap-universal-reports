using Epplus.Mapper.Annotations;
using System;

namespace UniversalReports.PlayForFun.Detail.Model
{
    public class DetailExcelModel
    {
        [Cell("A4")]
        public DateTime Date { get; set; }

        [Cell("B4")]
        public string GroupHeadline { get; set; }

        [Cell("C4")]
        public string Site { get; set; }

        [Cell("D4")]
        public string Currency { get; set; }

        [Cell("E4")]
        public string Super { get; set; }

        [Cell("F4")]
        public string Username { get; set; }

        [Cell("G4")]
        public int CustId { get; set; }

        [Cell("H4")]
        public string Product { get; set; }

        [Cell("I4")]
        public int Status { get; set; }

        [Cell("J4")]
        public int MemberRequest { get; set; }

        [Cell("K4")]
        public decimal Turnover { get; set; }

        [Cell("L4")]
        public decimal WinLoss { get; set; }

        [Cell("M4")]
        public int BetCount { get; set; }
    }
}
