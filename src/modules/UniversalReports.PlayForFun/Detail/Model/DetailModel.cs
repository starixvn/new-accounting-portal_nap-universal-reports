using System;

namespace UniversalReports.PlayForFun.Detail.Model
{
    public class DetailModel
    {
        public DateTime Date { get; set; }

        public string GroupHeadline { get; set; }

        public string Site { get; set; }

        public string Currency { get; set; }

        public string Super { get; set; }

        public string Username { get; set; }

        public int CustId { get; set; }

        public string Product { get; set; }

        public string Status { get; set; }

        public string MemberRequest { get; set; }

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public int BetCount { get; set; }

        public static DetailModel operator +(DetailModel a, DetailModel b)
        {
            return new DetailModel
            {
                Date = DateTime.MinValue,
                GroupHeadline = string.Empty,
                Currency = string.Empty,
                Site = string.Empty,
                Super = string.Empty,
                Username = string.Empty,
                CustId = 0,
                MemberRequest = "No",
                Product = string.Empty,
                Status = string.Empty,
                WinLoss = a.WinLoss + b.WinLoss,
                BetCount = a.BetCount + b.BetCount,
                Turnover = a.Turnover + b.Turnover
            };
        }
    }
}