using System;

namespace UniversalReports.PlayForFun.Summary.Model
{
    public class SummaryModel
    {
        public DateTime Date { get; set; }

        public int PlayerCount { get; set; }

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public int BetCount { get; set; }

        public static SummaryModel operator +(SummaryModel a, SummaryModel b)
        {
            return new SummaryModel
            {
                Date = DateTime.MinValue,
                WinLoss = a.WinLoss + b.WinLoss,
                BetCount = a.BetCount + b.BetCount,
                Turnover = a.Turnover + b.Turnover,
                PlayerCount = a.PlayerCount + b.PlayerCount
            };
        }
    }
}